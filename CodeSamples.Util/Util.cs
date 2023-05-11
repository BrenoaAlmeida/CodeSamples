using System.IO.Compression;
using System.Formats.Tar;

namespace CodeSamples.Util
{
    public class Util
    {
        public void CompactarArquivos(List<string> arquivosASeremCompactados, string caminho, string nome)
        {
            Dictionary<string, byte[]> arquivos = new Dictionary<string, byte[]>();
            foreach (string arquivo in arquivosASeremCompactados)
            {
                var diretorio = Path.Combine(caminho, arquivo);
                byte[] arquivoEmBytes = File.ReadAllBytes(diretorio);
                arquivos.Add(arquivo, arquivoEmBytes);
            }
            using (var memoryStream = new MemoryStream())
            {
                using (var archive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
                {
                    foreach (var arquivo in arquivos)
                    {
                        var archiveEntry = archive.CreateEntry(arquivo.Key);
                        using (var stream = archiveEntry.Open())
                        using (var binaryWriter = new BinaryWriter(stream))
                        {
                            binaryWriter.Write(arquivo.Value);
                        }
                    }
                }
                using (var fileStream = new FileStream(Path.Combine(caminho, nome), FileMode.Create))
                {
                    memoryStream.Seek(0, SeekOrigin.Begin);
                    memoryStream.CopyTo(fileStream);
                }
            }
        }

        public void ComprimirCarga(string nome, string caminho)
        {
            DirectoryInfo di = new DirectoryInfo(caminho);
            List<String> files = new List<String>();

            foreach (FileInfo fi in di.GetFiles().Where(d => d.Name.Substring(0, nome.Length) == nome))
            {
                files.Add(fi.Name);
            }
            string nomeArquivo = nome + ".zip";
            CompactarArquivos(files, caminho, nomeArquivo);
        }

        //Usado no .NET 7 para frente
        public void CriarArquivoTar(string caminhoArquivoFonte, string caminhoDestino)
        {
            TarFile.CreateFromDirectory(caminhoArquivoFonte, caminhoDestino, false);
            Console.WriteLine("");
            Console.WriteLine("Arquivo TAR criado com sucesso!!");
        }

        public void ExtrairArquivoTar(string caminhoArquivoFonte, string caminhoDestino)
        {
            TarFile.ExtractToDirectory(caminhoArquivoFonte, caminhoDestino, false);
            Console.WriteLine("");
            Console.WriteLine("Arquivo TAR extraido com sucesso para o seguinte caminho: ");
            Console.WriteLine(caminhoDestino);
        }
    }
}