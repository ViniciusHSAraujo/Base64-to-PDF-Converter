using System;
using System.IO;
using System.Windows.Forms;

namespace Base64_to_PDF_Decoder
{
    public partial class Form1 : Form
    {
        private readonly string _localBase;
        private readonly string _localConfig;
        private string _localSalvamentoDoArquivo;

        public Form1()
        {
            _localBase = Application.StartupPath;
            _localConfig = $@"{Application.StartupPath}\base.config";
            InitializeComponent();
            PegarConfig();
        }

        private void PegarConfig()
        {
            if (!File.Exists(_localConfig))
            {
                var arquivoConfig = File.CreateText(_localConfig);
                arquivoConfig.Write(_localBase);
                arquivoConfig.Close();
            }

            _localSalvamentoDoArquivo = File.ReadAllText(_localConfig);

            tbLocalArquivo.Text = _localSalvamentoDoArquivo;
        }

        private void btnConverter_Click(object sender, EventArgs e)
        {
            try
            {
                ValidarCamposEmBranco();
                byte[] bytes = ConverterBase64ParaArrayDeBytes();
                GerarArquivoPDF(bytes);
                ExibirDialogDeInformacao(@$"Arquivo convertido com sucesso!");
                LimparCampos();
            }
            catch (FormatException ex)
            {
                ExibirDialogDeErro($"O Base64 informado não é válido! Erro: {ex.Message}");
            }
            catch (Exception ex)
            {
                ExibirDialogDeErro(ex.Message);
            }

        }

        private void LimparCampos()
        {
            if (chkLimparNome.Checked)
                tbNomeDoArquivo.Text = string.Empty;
            tbBase64.Text = string.Empty;
        }

        private void GerarArquivoPDF(byte[] bytes)
        {
            if (File.Exists(@$"{_localSalvamentoDoArquivo}\{tbNomeDoArquivo.Text}.pdf"))
            {
                var confirmacao = ExibirDialogDeConfirmacao("Este arquivo já existe, deseja sobrescrevê-lo?");
                if (confirmacao != DialogResult.OK)
                    throw new Exception("Geração de arquivo cancelada pelo usuário.");
                
                File.Delete(@$"{_localSalvamentoDoArquivo}\{tbNomeDoArquivo.Text}.pdf");
            }

            FileStream stream = new FileStream(@$"{_localSalvamentoDoArquivo}\{tbNomeDoArquivo.Text}.pdf", FileMode.CreateNew);
            BinaryWriter writer = new BinaryWriter(stream);
            writer.Write(bytes, 0, bytes.Length);
            writer.Close();
        }

        private byte[] ConverterBase64ParaArrayDeBytes()
        {
            var txtBase64 = tbBase64.Text;
            byte[] bytes = Convert.FromBase64String(txtBase64);
            return bytes;
        }

        private void ValidarCamposEmBranco()
        {
            if (string.IsNullOrWhiteSpace(tbNomeDoArquivo.Text))
            {
                throw new Exception("Você não definiu o nome do arquivo!");
            }

            if (string.IsNullOrWhiteSpace(tbBase64.Text))
            {
                throw new Exception("Você não disponibilizou o base64 do arquivo!");
            }
        }

        private static void ExibirDialogDeErro(string mensagem)
        {
            MessageBox.Show(mensagem, "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private static void ExibirDialogDeInformacao(string mensagem)
        {
            MessageBox.Show(mensagem, "Informação!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private static DialogResult ExibirDialogDeConfirmacao(string mensagem)
        {
            return MessageBox.Show(mensagem, "Você tem certeza disso?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
        }

        private void tbLocalArquivo_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                tbLocalArquivo.Text = folderBrowserDialog1.SelectedPath;
                _localSalvamentoDoArquivo = folderBrowserDialog1.SelectedPath;
                File.WriteAllText(_localConfig, folderBrowserDialog1.SelectedPath);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
