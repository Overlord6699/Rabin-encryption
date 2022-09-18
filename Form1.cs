using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private RabinEncryptor encryptor;
        private RabinDecryptor decryptor;


        public enum Mode
        {
            Bytes, Text
        }

        public enum EncryptionMode
        {
            Encrypt, Decrypt
        }

        private EncryptionMode encMode;
        private Mode mode = Mode.Text;

        const int FORMAT_SIZE = 2;
        //ввод
        byte[] byteArr;
        BigInteger[] intArr;

        //вывод
        BigInteger[,] result;
        BigInteger[] concreteResult;

        //ограничение размера
        int limit;

        public Form1()
        {
            InitializeComponent();
        }

        #region transformation

        private string ArrayToString(in BigInteger[] arr, in int limit)
        {
            string output = "";

            for (int i = 0; i < limit; i++)
            {
                output += arr[i].ToString();

                if (i != limit - 1)
                {
                    output += " ";
                }
            }

            return output;
        }

        private string ArrayToString(in int[] arr)
        {
            string output = "";

            for (int i = 0; i < arr.Length; i++)
            {
                output += arr[i].ToString();

                if (i != arr.Length - 1)
                {
                    output += " ";
                }
            }

            return output;
        }

        private BigInteger[] CreateIntArray(in byte[] bytes)
        {
            //каждое число будет представлено максимальным числом байт в файле
            byte size = Convert.ToByte(SizeTB.Text);
            BigInteger[] intArr = new BigInteger[bytes.Length/size];

            for (int i = 0; i < intArr.Length; i++)
            {
                //выделим лишний байт в конец для создания unsigned и заполним его нулём
                byte[] number = new byte[size+1];
                for(int j = 0; j < size; j++)
                {
                    number[j] = bytes[i * size + j];
                }

                number[size] = 0; 

                intArr[i] = new BigInteger(number);
            }

            return intArr;
        }

        private byte[] CreateByteArrayFromString(string input)
        {
            string[] bytes = input.Split(' ');

            byte[] inputBytes = new byte[bytes.Length];

            for (int i = 0; i < bytes.Length; i++)
                inputBytes[i] = Convert.ToByte(bytes[i]);

            return inputBytes;
        }

        private BigInteger[] CreateIntArrayFromString(string input)
        {
            string[] bytes = input.Split(' ');

            BigInteger[] inputBytes = new BigInteger[bytes.Length];

            for (int i = 0; i < bytes.Length; i++)
                inputBytes[i] = BigInteger.Parse(bytes[i]);


            return inputBytes;
        }

        private byte[] CreateByteArray(in BigInteger[] concreteResult)
        {
            byte[] outputBytes = new byte[concreteResult.Length];

            int index = 0;
            for (int i = 0; i < concreteResult.Length; i++)
            {
                //выделяется 2 байта, но второй не нужен (0)
                byte[] arr = concreteResult[i].ToByteArray();
                outputBytes[i] = arr[0];
            }

            return outputBytes;
        }

        private byte[] CreateByteFromBigArray(in BigInteger[] concreteResult)
        {
            //каждое число будет представлено максимальным числом байт в файле
            byte size = Convert.ToByte(SizeTB.Text);
            byte[] outputBytes = new byte[concreteResult.Length * size];
            //byte[] outputBytes = new byte[0];
            int index = 0;
            for (int i = 0; i < concreteResult.Length; i++)
            {
                
                byte[] arr = concreteResult[i].ToByteArray();
                /*
                arr.CopyTo(outputBytes, index);
                index += arr.Length;
                */


                //заполнение полученными байтами
                for (int j = 0; j < arr.Length; j++)
                {
                    outputBytes[i * size + j] = arr[j];
                }
                
            }
            /*
            byte[] smallerArr = new byte[index];
            for(int i = 0; i < index; i++)
            {
                smallerArr[i] = outputBytes[i];
            }
          
            return smallerArr;
              */
            return outputBytes;
        }

        private int[] BytesToInt(byte[] bytes)
        {
            byte bytesPerSymbol = Convert.ToByte(SizeTB.Text);

            int arrSize = (int)Math.Ceiling((double) bytes.Length / bytesPerSymbol);
            var ints = new int[arrSize];

            Buffer.BlockCopy(bytes, 0, ints, 0, bytes.Length);

            return ints;
        }

        private byte[] IntToBytes(int[] ints)
        {
            byte bytesPerSymbol = Convert.ToByte(SizeTB.Text);

            int arrSize = ints.Length * bytesPerSymbol;
            var bytes = new byte[arrSize];

            Buffer.BlockCopy(ints, 0, bytes, 0, ints.Length);

            return bytes;
        }

        #endregion

        private void GetBuferSize(in int dataLength)
        {
            int buferSize = Convert.ToInt32(BuferTB.Text);

            limit = Math.Min(buferSize, dataLength);
        }

        private byte CalculateMaxSizeInBytes(in BigInteger[] result)
        {
            byte[] NumOfBitsPerSymbol = new byte[result.Length];

            for (int i = 0; i < result.Length; i++)
            {
                NumOfBitsPerSymbol[i] = (byte)Math.Ceiling(Math.Log((double)result[i] + 1, 2));
            }

            byte numOfBits = NumOfBitsPerSymbol.Max();
            byte numOfBytes = (byte)Math.Ceiling((double)(numOfBits / 8));
            numOfBytes++;

            return numOfBytes;
        }

        private void SetBytesPerSymbol(in byte size)
        {
            SizeTB.Text = size.ToString();
        }

        private void Encrypt_Click(object sender, EventArgs e)
        {
            if (encryptor != null)
            {
                if (InputTB.Text.Length > 0)
                {
                    //шифрование текста
                    if (mode == Mode.Text)
                    {
                        string input = InputTB.Text;
                        byteArr = Encoding.ASCII.GetBytes(input);
                    }/*
                    else
                    {
                        byteArr = CreateByteArrayFromString(InputTB.Text);
                    }*/

                    concreteResult = encryptor.Encrypt(byteArr);

                    SetBytesPerSymbol(CalculateMaxSizeInBytes(concreteResult));

                    GetBuferSize(concreteResult.Length);
                    FillSimpleOutput(concreteResult);

                    encMode = EncryptionMode.Encrypt;
                }
                else
                    MessageBox.Show("Сначала необходимо заполнить входные данные");
            }
            else
                MessageBox.Show("Сначала необходимо заполнить данные");          
        }

        #region output
        private void FillOutput(in byte[] bytes)
        {
            string output = "";
            int i;

            for (i = 0; i < bytes.Length-1; i++)
            {
                output += (bytes[i] > 0) ?
                       bytes[i].ToString("D4")+" " :
                       bytes[i].ToString("D3")+" ";
            }
            output += (bytes[i] > 0) ?
                       bytes[i].ToString("D4") :
                       bytes[i].ToString("D3");

            OutputTB.Text = output;
        }

        private void FillOst(in BigInteger[,] bytes)
        {
            string output = "";
            int j;

            for (int i = 0; i < bytes.GetLength(0); i++)
            {
                for (j = 0; j < bytes.GetLength(1) - 1; j++)
                    output += (bytes[i, j] > 0) ?
                        bytes[i, j].ToString("D4") + " " :
                        bytes[i, j].ToString("D3") + " ";

                output += (bytes[i, j] > 0) ?
                        bytes[i, j].ToString("D4") :
                        bytes[i, j].ToString("D3");

                output += Environment.NewLine;
            }

            OstBox.Text = output;
        }

        private void FillOutput(in BigInteger[,] bytes)
        {
            string output = "";
            int j;

            for (int i = 0; i < limit; i++)
            {
                for (j = 0; j < bytes.GetLength(1) - 1; j++)
                {
                    output += (bytes[i, j] > 0) ?
                       bytes[i, j].ToString("D4") + " " :
                       bytes[i, j].ToString("D3") + " ";
                }

                output += (bytes[i, j] > 0) ?
                       bytes[i, j].ToString("D4") :
                       bytes[i, j].ToString("D3");

                output += Environment.NewLine;
            }

            OutputTB.Text = output;
        }

        private void FillOutput(in byte[,] bytes)
        {
            string output = "";
            int j;

            for (int i = 0; i < bytes.GetLength(0); i++)
            {
                for (j = 0; j < bytes.GetLength(1) - 1; j++)
                {
                    output += (bytes[i, j] > 0) ?
                       bytes[i, j].ToString("D4") + " " :
                       bytes[i, j].ToString("D3") + " ";
                }

                output += (bytes[i, j] > 0) ?
                       bytes[i, j].ToString("D4") :
                       bytes[i, j].ToString("D3");

                output += Environment.NewLine;
            }

            OutputTB.Text = output;
        }

        private void FillSimpleOutput(in BigInteger[] bytes)
        {
            string output = "";

            for (int i = 0; i < limit; i++)
            {
                output += bytes[i].ToString();

                if(i != limit - 1)
                {
                    output += " ";
                }
            }

            OutputTB.Text = output;
        }

 

        private void FillConcreteOutput(in BigInteger[] bytes)
        {
            string output = "";

            for (int i = 0; i < limit; i++)
            {
                output += bytes[i].ToString();

                if (i != limit - 1)
                {
                    output += " ";
                }
            }


            OutputTB.Text = output;
        }

        private void FillOutput(in int[] bytes)
        {
            string output = "";
            int i;

            for (i = 0; i < bytes.Length-1; i++)
            {
                output += (bytes[i] > 0) ?
                       bytes[i].ToString("D4") + " " :
                       bytes[i].ToString("D3")+ " ";
            }
            output += (bytes[i] > 0) ?
                       bytes[i].ToString("D4") :
                       bytes[i].ToString("D3");

            OutputTB.Text = output;
        }

        private void FillOutput(in int[,] bytes)
        {
            string output = "";
            int j;

            for (int i = 0; i < bytes.GetLength(0); i++)
            {
                for (j = 0; j < bytes.GetLength(1) - 1; j++)
                    output += (bytes[i,j] > 0)? 
                        bytes[i, j].ToString("D4") + " ":
                        bytes[i, j].ToString("D3") + " ";

                output += (bytes[i, j] > 0) ?
                        bytes[i, j].ToString("D4"):
                        bytes[i, j].ToString("D3");

                output += Environment.NewLine;
            }

            OutputTB.Text = output;
        }

        #endregion

        private BigInteger[] GetConcreteOutput(in BigInteger[,] matrix)
        {
            BigInteger[] result = new BigInteger[matrix.GetLength(0)];

            int index = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                    if (matrix[i, j] < 256 && matrix[i, j] > -1)
                    {
                        result[index] = matrix[i, j];
                        index++;

                        break;
                    }
            }

            return result;
        }

        private bool IsPrimary_MillerRabin(BigInteger n, in int s) 
        {
            if (n == 2 || n == 3)
                return true;

            if (n < 2 || n % 2 == 0)
                return false;


            // представление n − 1 в виде (2^k)*m (m -неч.)
            //нужно много раз делить  n - 1 на 2
            BigInteger m = n - 1;
            int k = 0;

            while (m % 2 == 0)
            {
                m /= 2;
                k += 1;
            }
            // s раундов
            for (int i = 0; i < s; i++)
            {
                // выберем случайное целое число a в отрезке [2, n − 2]

                RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();

                byte[] _a = new byte[n.ToByteArray().LongLength];

                BigInteger a;

                do
                {
                    rng.GetBytes(_a);
                    a = new BigInteger(_a);
                    //MessageBox.Show(a.ToString());
                }
                while (a < 2 || a >= n - 2);

                BigInteger b_i = FastPowModFunc(a, m, n);

                // если b_i == 1 или b_i == n − 1, то перейти на следующую итерацию цикла
                if (b_i == 1 || b_i == n - 1)
                    continue;

                // повторить k − 1 раз
                for (int r = 1; r < k; r++)
                {
                    b_i = FastPowModFunc(b_i, 2, n);

                    // если b_i == 1, то число составное
                    if (b_i == 1)
                        return false;

                    // если b_i == n − 1, то перейти на следующую итерацию внешнего цикла
                    if (b_i == n - 1)
                        break;
                }

                if (b_i != n - 1)
                    return false;
            }

            // "вероятно простое"
            return true;

        }

        public static BigInteger FastPowModFunc(BigInteger num, BigInteger pow, BigInteger mod)
        {
            BigInteger res = 1;
            BigInteger bit = num % mod;

            while (pow > 0)
            {
                if ((pow & 1) == 1)
                {
                    res *= bit;
                    res %= mod;
                }
                bit *= bit;
                bit %= mod;
                pow >>= 1;
            }
            return res;
        }

        private bool IsCorrectNumber(in BigInteger num)
        {
            
            if(num % 4 != 3)
            {
                MessageBox.Show("Должно выполняться правило: a % 4 = 3");
                return false;
            }

            if(!IsPrimary_MillerRabin(num,10))
            {
                MessageBox.Show("Числа должны быть простыми");
                return false;
            }

            return true;
        }

        private BigInteger GetValueFromTextBox(in string name, in string source)
        {
            BigInteger value;

            try
            {
                value = BigInteger.Parse(source);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Некорректное значение {name}");
                return -1;
            }

            return value;
        }

        private void Generate_Click(object sender, EventArgs e)
        {
            ClearText();

            SizeTB.Text = "1";

            if(PTextBox.Text == "" || QTextBox.Text == "")
            {
                MessageBox.Show("Заполните p и q");
                return;
            }

            BigInteger p;
            if ((p = GetValueFromTextBox("p", PTextBox.Text)) == -1)
                return;

            BigInteger q;
            if ((q = GetValueFromTextBox("q", QTextBox.Text)) == -1)
                return;



            if (!IsCorrectNumber(p))
                return;
            if (!IsCorrectNumber(q))
                return;

            encryptor = new RabinEncryptor(p,q);


            if (BTextBox.Text.Length > 0)
            {
                BigInteger b;
                if ((b = GetValueFromTextBox("b", BTextBox.Text)) == -1)
                    return;

                if (!encryptor.SetB(b))
                {
                    MessageBox.Show("b должно быть меньше n");
                    return;
                }
            }
            else
                BTextBox.Text = encryptor.GetB().ToString();

            MessageBox.Show("Ввод выполнен корректно");

            if (mode == Mode.Text)
                MessageBox.Show("Внимание: стоит текстовый режим");
        }

        private bool CheckConcreteOutput()
        {
            bool isCorrect = false;

            for(int i = 0; i < limit; i++)
            {
                if(concreteResult[i] != 0)
                {
                    isCorrect = true;
                    break;
                }
            }

            return isCorrect;
        }

        private void Decrypt_Click(object sender, EventArgs e)
        {
            if (encryptor != null)
            {             
                if (InputTB.Text.Length > 0)
                {
                    decryptor = new RabinDecryptor(encryptor.N,
                    encryptor.GetSecretKey(), encryptor.GetB());

                    if (mode == Mode.Text)
                    {
                        intArr = CreateIntArrayFromString(InputTB.Text);
                    }

                    result = decryptor.Decrypt(intArr);

                    /* DEBUG
                    //MessageBox.Show("Mp: " + ArrayToString( decryptor.M_p));
                    //MessageBox.Show("Mq: " + ArrayToString(decryptor.M_q));
                    //MessageBox.Show("Yp: " + decryptor.Yp + " Yq: " + decryptor.Yq);

                    //FillOst(decryptor.GetOstArray());

                    //matrix
                    //FillOutput(result);
                    */
                 
                    concreteResult = GetConcreteOutput(result);

                    GetBuferSize(concreteResult.Length);

                    if (CheckConcreteOutput())
                    {
                        //стоит проверить точный вывод на наличие подходящих байт
                        FillConcreteOutput(concreteResult);
                    }
                    else
                    {
                        MessageBox.Show("Нет подходящей дешифровки");
                        FillOutput(result);
                    }
                    
                    SetBytesPerSymbol(1);
                    encMode = EncryptionMode.Decrypt;
                }
                else
                    MessageBox.Show("Сначала необходимо заполнить входные данные");
            }
            else
                MessageBox.Show("Сначала необходимо заполнить данные");
        }  

        private void SaveFile_Click(object sender, EventArgs e)
        {
            if (OutputTB.Text.Length > 0)
            {
                if(openFileDialog1.ShowDialog() != DialogResult.Cancel)
                {
                    //запись в файл больших чисел
                    if (encMode == EncryptionMode.Encrypt)
                    {
                        byte[] outputBytes = CreateByteFromBigArray(concreteResult);
                        File.WriteAllBytes(openFileDialog1.FileName, outputBytes);
                    }
                    else//запись в файл байт
                    {
                        byte[] outputBytes = CreateByteArray(concreteResult);
                        File.WriteAllBytes(openFileDialog1.FileName, outputBytes);
                    }
                }
            }
            else
                MessageBox.Show("Нечего сохранять");
        }

        private void ClearText()
        {
            InputTB.Text = "";
            OutputTB.Text = "";
        }

        private void OpenFile_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() != DialogResult.Cancel)
            {
                ClearText();
                
                byteArr = File.ReadAllBytes(openFileDialog1.FileName);

               
                intArr = CreateIntArray(byteArr);
                GetBuferSize(intArr.Length);

                string input = ArrayToString(intArr, limit);

                InputTB.Text = input;
            }
        }

        private void Swapbutton_Click(object sender, EventArgs e)
        {
            InputTB.Text = OutputTB.Text;
            OutputTB.Text = "";

            intArr = concreteResult;
        }

        private void Switch_Click(object sender, EventArgs e)
        {
            if(mode == Mode.Bytes)
            {
                mode = Mode.Text;
                SwitchLabel.Text = "Text";
            }
            else
            {
                mode = Mode.Bytes;
                SwitchLabel.Text = "Bytes";
            }
        }
    }
}
