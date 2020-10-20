using Base64_to_PDF_Decoder.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json.Serialization;
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
                if (!cbModoJson.Checked)
                {
                    byte[] bytes = ConverterBase64ParaArrayDeBytes(tbBase64.Text);
                    GerarArquivoPDF(bytes, tbNomeDoArquivo.Text);
                    ExibirDialogDeInformacao(@$"Arquivo convertido com sucesso!");
                }
                else
                {
                    List<ResponseJson> arquivos;
                    try
                    {
                        arquivos = JsonConvert.DeserializeObject<List<ResponseJson>>(tbBase64.Text);
                    }
                    catch (Exception)
                    {
                        throw new Exception("O arquivo JSON enviado não é do formato válido!");
                    }

                    foreach (var arquivo in arquivos)
                    {
                        byte[] bytes = ConverterBase64ParaArrayDeBytes(arquivo.FileContent);
                        GerarArquivoPDF(bytes, arquivo.NomeArquivo[0..^4]);
                    }

                }
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

        private void GerarArquivoPDF(byte[] bytes, string nomeDoArquivo)
        {
            if (File.Exists(@$"{_localSalvamentoDoArquivo}\{nomeDoArquivo}.pdf"))
            {
                var confirmacao = ExibirDialogDeConfirmacao("Este arquivo já existe, deseja sobrescrevê-lo?");
                if (confirmacao != DialogResult.OK)
                    throw new Exception("Geração de arquivo cancelada pelo usuário.");

                File.Delete(@$"{_localSalvamentoDoArquivo}\{tbNomeDoArquivo.Text}.pdf");
            }

            FileStream stream = new FileStream(@$"{_localSalvamentoDoArquivo}\{nomeDoArquivo}.pdf", FileMode.CreateNew);
            BinaryWriter writer = new BinaryWriter(stream);
            writer.Write(bytes, 0, bytes.Length);
            writer.Close();
        }

        private byte[] ConverterBase64ParaArrayDeBytes(string text)
        {
            var txtBase64 = text;
            byte[] bytes = Convert.FromBase64String(txtBase64);
            return bytes;
        }

        private void ValidarCamposEmBranco()
        {
            if (!cbModoJson.Checked && string.IsNullOrWhiteSpace(tbNomeDoArquivo.Text))
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

        private void cbModoJson_CheckedChanged(object sender, EventArgs e)
        {
            if (cbModoJson.Checked)
            {
                tbNomeDoArquivo.Enabled = false;
                chkLimparNome.Enabled = false;
            }
            else
            {
                tbNomeDoArquivo.Enabled = true;
                chkLimparNome.Enabled = true;
            }
        }
    }
}
