using System.IO.Compression;
using System.Formats.Tar;
using System.Text;

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

        public static List<T> CarregarTextoParaUmArquivoComHeaders<T>(string caminhoDoArquivo) where T : class, new()
        {
            var linhas = File.ReadAllLines(caminhoDoArquivo).ToList();

            if (linhas.Count < 2)
                throw new IndexOutOfRangeException("Arquivo vazio ou não encontrado.");

            List<T> output = new List<T>();
            T entry = new T();
            var colunas = entry.GetType().GetProperties();

            var headers = linhas[0].Split(',');

            linhas.RemoveAt(0);

            foreach (var linha in linhas)
            {
                entry = new T();
                var valores = linha.Split(',');

                for (var i = 0; i < headers.Length; i++)
                {
                    foreach (var coluna in colunas)
                    {
                        if (coluna.Name == headers[i])
                            coluna.SetValue(entry, Convert.ChangeType(valores[i], coluna.PropertyType));

                    }
                }

                output.Add(entry);

            }

            return output;
        }

        public static void SalvarTextoParaUmArquivoComHeaders<T>(List<T> data, string caminhoDoArquivo) where T : class
        {
            if (data == null || data.Count == 0)
                throw new ArgumentNullException("data", "O parametro data deve conter pelo menos um valor.");


            List<string> linhas = new List<string>();
            StringBuilder linha = new StringBuilder();

            var colunas = data[0].GetType().GetProperties();
            
            foreach (var coluna in colunas)
            {
                linha.Append(coluna.Name);
                linha.Append(",");
            }
            
            //Adiciona o Header do Arquivo na primeira linha
            linhas.Add(linha.ToString().Substring(0, linha.Length - 1));

            foreach (var row in data)
            {
                linha = new StringBuilder();

                foreach (var col in colunas)
                {
                    linha.Append(col.GetValue(row));
                    linha.Append(",");
                }
                
                linhas.Add(linha.ToString().Substring(0, linha.Length - 1));
            }

            File.WriteAllLines(caminhoDoArquivo, linhas);
        }
    }
}