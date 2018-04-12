using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2PD_iSaugumas
{
    public partial class PagrindisLangas : Form
    {
        public PagrindisLangas()
        {
            InitializeComponent();
        }

        private string message = "Mano Zinute 2018";
        private string key = "Mano Slaptas Key";

        private string[,] sBox =
 {
    { "63", "7C", "77", "7B", "F2", "6B", "6F", "C5", "30", "01", "67", "2B", "FE", "D7", "AB", "76" },
    { "CA", "82", "C9", "7D", "FA", "59", "47", "F0", "AD", "D4", "A2", "AF", "9C", "A4", "72", "C0" },
    { "B7", "FD", "93", "26", "36", "3F", "F7", "CC", "34", "A5", "E5", "F1", "71", "D8", "31", "15" },
    { "04", "C7", "23", "C3", "18", "96", "05", "9A", "07", "12", "80", "E2", "EB", "27", "B2", "75" },
    { "09", "83", "2C", "1A", "1B", "6E", "5A", "A0", "52", "3B", "D6", "B3", "29", "E3", "2F", "84" },
    { "53", "D1", "00", "ED", "20", "FC", "B1", "5B", "6A", "CB", "BE", "39", "4A", "4C", "58", "CF" },
    { "D0", "EF", "AA", "FB", "43", "4D", "33", "85", "45", "F9", "02", "7F", "50", "3C", "9F", "A8" },
    { "51", "A3", "40", "8F", "92", "9D", "38", "F5", "BC", "B6", "DA", "21", "10", "FF", "F3", "D2" },
    { "CD", "0C", "13", "EC", "5F", "97", "44", "17", "C4", "A7", "7E", "3D", "64", "5D", "19", "73" },
    { "60", "81", "4F", "DC", "22", "2A", "90", "88", "46", "EE", "B8", "14", "DE", "5E", "0B", "DB" },
    { "E0", "32", "3A", "0A", "49", "06", "24", "5C", "C2", "D3", "AC", "62", "91", "95", "E4", "79" },
    { "E7", "C8", "37", "6D", "8D", "D5", "4E", "A9", "6C", "56", "F4", "EA", "65", "7A", "AE", "08" },
    { "BA", "78", "25", "2E", "1C", "A6", "B4", "C6", "E8", "DD", "74", "1F", "4B", "BD", "8B", "8A" },
    { "70", "3E", "B5", "66", "48", "03", "F6", "0E", "61", "35", "57", "B9", "86", "C1", "1D", "9E" },
    { "E1", "F8", "98", "11", "69", "D9", "8E", "94", "9B", "1E", "87", "E9", "CE", "55", "28", "DF" },
    { "8C", "A1", "89", "0D", "BF", "E6", "42", "68", "41", "99", "2D", "0F", "B0", "54", "BB", "16" }
 };
        private string[] RC = { "01", "02", "04", "08", "10", "20", "40", "80", "1B", "36" };
        private string[,] inverseSbox = {
    {"52", "09", "6A", "D5", "30", "36", "A5", "38", "BF", "40", "A3", "9E", "81", "F3", "D7", "FB"},
    {"7C", "E3", "39", "82", "9B", "2F", "FF", "87", "34", "8E", "43", "44", "C4", "DE", "E9", "CB"},
    {"54", "7B", "94", "32", "A6", "C2", "23", "3D", "EE", "4C", "95", "0B", "42", "FA", "C3", "4E"},
    {"08", "2E", "A1", "66", "28", "D9", "24", "B2", "76", "5B", "A2", "49", "6D", "8B", "D1", "25"},
    {"72", "F8", "F6", "64", "86", "68", "98", "16", "D4", "A4", "5C", "CC", "5D", "65", "B6", "92"},
    {"6C", "70", "48", "50", "FD", "ED", "B9", "DA", "5E", "15", "46", "57", "A7", "8D", "9D", "84"},
    {"90", "D8", "AB", "00", "8C", "BC", "D3", "0A", "F7", "E4", "58", "05", "B8", "B3", "45", "06"},
    {"D0", "2C", "1E", "8F", "CA", "3F", "0F", "02", "C1", "AF", "BD", "03", "01", "13", "8A", "6B"},
    {"3A", "91", "11", "41", "4F", "67", "DC", "EA", "97", "F2", "CF", "CE", "F0", "B4", "E6", "73"},
    {"96", "AC", "74", "22", "E7", "AD", "35", "85", "E2", "F9", "37", "E8", "1C", "75", "DF", "6E"},
    {"47", "F1", "1A", "71", "1D", "29", "C5", "89", "6F", "B7", "62", "0E", "AA", "18", "BE", "1B"},
    {"FC", "56", "3E", "4B", "C6", "D2", "79", "20", "9A", "DB", "C0", "FE", "78", "CD", "5A", "F4"},
    {"1F", "DD", "A8", "33", "88", "07", "C7", "31", "B1", "12", "10", "59", "27", "80", "EC", "5F"},
    {"60", "51", "7F", "A9", "19", "B5", "4A", "0D", "2D", "E5", "7A", "9F", "93", "C9", "9C", "EF"},
    {"A0", "E0", "3B", "4D", "AE", "2A", "F5", "B0", "C8", "EB", "BB", "3C", "83", "53", "99", "61"},
    {"17", "2B", "04", "7E", "BA", "77", "D6", "26", "E1", "69", "14", "63", "55", "21", "0C", "7D"}

 };
        private string[] mc9 = {"00","09","12","1b","24","2d","36","3f","48","41","5a","53","6c","65","7e","77",
"90","99","82","8b","b4","bd","a6","af","d8","d1","ca","c3","fc","f5","ee","e7",
"3b","32","29","20","1f","16","0d","04","73","7a","61","68","57","5e","45","4c",
"ab","a2","b9","b0","8f","86","9d","94","e3","ea","f1","f8","c7","ce","d5","dc",
"76","7f","64","6d","52","5b","40","49","3e","37","2c","25","1a","13","08","01",
"e6","ef","f4","fd","c2","cb","d0","d9","ae","a7","bc","b5","8a","83","98","91",
"4d","44","5f","56","69","60","7b","72","05","0c","17","1e","21","28","33","3a",
"dd","d4","cf","c6","f9","f0","eb","e2","95","9c","87","8e","b1","b8","a3","aa",
"ec","e5","fe","f7","c8","c1","da","d3","a4","ad","b6","bf","80","89","92","9b",
"7c","75","6e","67","58","51","4a","43","34","3d","26","2f","10","19","02","0b",
"d7","de","c5","cc","f3","fa","e1","e8","9f","96","8d","84","bb","b2","a9","a0",
"47","4e","55","5c","63","6a","71","78","0f","06","1d","14","2b","22","39","30",
"9a","93","88","81","be","b7","ac","a5","d2","db","c0","c9","f6","ff","e4","ed",
"0a","03","18","11","2e","27","3c","35","42","4b","50","59","66","6f","74","7d",
"a1","a8","b3","ba","85","8c","97","9e","e9","e0","fb","f2","cd","c4","df","d6",
"31","38","23","2a","15","1c","07","0e","79","70","6b","62","5d","54","4f","46"};
        private string[] mc11 = {"00","0b","16","1d","2c","27","3a","31","58","53","4e","45","74","7f","62","69",
"b0","bb","a6","ad","9c","97","8a","81","e8","e3","fe","f5","c4","cf","d2","d9",
"7b","70","6d","66","57","5c","41","4a","23","28","35","3e","0f","04","19","12",
"cb","c0","dd","d6","e7","ec","f1","fa","93","98","85","8e","bf","b4","a9","a2",
"f6","fd","e0","eb","da","d1","cc","c7","ae","a5","b8","b3","82","89","94","9f",
"46","4d","50","5b","6a","61","7c","77","1e","15","08","03","32","39","24","2f",
"8d","86","9b","90","a1","aa","b7","bc","d5","de","c3","c8","f9","f2","ef","e4",
"3d","36","2b","20","11","1a","07","0c","65","6e","73","78","49","42","5f","54",
"f7","fc","e1","ea","db","d0","cd","c6","af","a4","b9","b2","83","88","95","9e",
"47","4c","51","5a","6b","60","7d","76","1f","14","09","02","33","38","25","2e",
"8c","87","9a","91","a0","ab","b6","bd","d4","df","c2","c9","f8","f3","ee","e5",
"3c","37","2a","21","10","1b","06","0d","64","6f","72","79","48","43","5e","55",
"01","0a","17","1c","2d","26","3b","30","59","52","4f","44","75","7e","63","68",
"b1","ba","a7","ac","9d","96","8b","80","e9","e2","ff","f4","c5","ce","d3","d8",
"7a","71","6c","67","56","5d","40","4b","22","29","34","3f","0e","05","18","13",
"ca","c1","dc","d7","e6","ed","f0","fb","92","99","84","8f","be","b5","a8","a3"};
        private string[] mc13 = { "00","0d","1a","17","34","39","2e","23","68","65","72","7f","5c","51","46","4b",
"d0","dd","ca","c7","e4","e9","fe","f3","b8","b5","a2","af","8c","81","96","9b",
"bb","b6","a1","ac","8f","82","95","98","d3","de","c9","c4","e7","ea","fd","f0",
"6b","66","71","7c","5f","52","45","48","03","0e","19","14","37","3a","2d","20",
"6d","60","77","7a","59","54","43","4e","05","08","1f","12","31","3c","2b","26",
"bd","b0","a7","aa","89","84","93","9e","d5","d8","cf","c2","e1","ec","fb","f6",
"d6","db","cc","c1","e2","ef","f8","f5","be","b3","a4","a9","8a","87","90","9d",
"06","0b","1c","11","32","3f","28","25","6e","63","74","79","5a","57","40","4d",
"da","d7","c0","cd","ee","e3","f4","f9","b2","bf","a8","a5","86","8b","9c","91",
"0a","07","10","1d","3e","33","24","29","62","6f","78","75","56","5b","4c","41",
"61","6c","7b","76","55","58","4f","42","09","04","13","1e","3d","30","27","2a",
"b1","bc","ab","a6","85","88","9f","92","d9","d4","c3","ce","ed","e0","f7","fa",
"b7","ba","ad","a0","83","8e","99","94","df","d2","c5","c8","eb","e6","f1","fc",
"67","6a","7d","70","53","5e","49","44","0f","02","15","18","3b","36","21","2c",
"0c","01","16","1b","38","35","22","2f","64","69","7e","73","50","5d","4a","47",
"dc","d1","c6","cb","e8","e5","f2","ff","b4","b9","ae","a3","80","8d","9a","97" };
        private string[] mc14 = {"00","0e","1c","12","38","36","24","2a","70","7e","6c","62","48","46","54","5a",
"e0","ee","fc","f2","d8","d6","c4","ca","90","9e","8c","82","a8","a6","b4","ba",
"db","d5","c7","c9","e3","ed","ff","f1","ab","a5","b7","b9","93","9d","8f","81",
"3b","35","27","29","03","0d","1f","11","4b","45","57","59","73","7d","6f","61",
"ad","a3","b1","bf","95","9b","89","87","dd","d3","c1","cf","e5","eb","f9","f7",
"4d","43","51","5f","75","7b","69","67","3d","33","21","2f","05","0b","19","17",
"76","78","6a","64","4e","40","52","5c","06","08","1a","14","3e","30","22","2c",
"96","98","8a","84","ae","a0","b2","bc","e6","e8","fa","f4","de","d0","c2","cc",
"41","4f","5d","53","79","77","65","6b","31","3f","2d","23","09","07","15","1b",
"a1","af","bd","b3","99","97","85","8b","d1","df","cd","c3","e9","e7","f5","fb",
"9a","94","86","88","a2","ac","be","b0","ea","e4","f6","f8","d2","dc","ce","c0",
"7a","74","66","68","42","4c","5e","50","0a","04","16","18","32","3c","2e","20",
"ec","e2","f0","fe","d4","da","c8","c6","9c","92","80","8e","a4","aa","b8","b6",
"0c","02","10","1e","34","3a","28","26","7c","72","60","6e","44","4a","58","56",
"37","39","2b","25","0f","01","13","1d","47","49","5b","55","7f","71","63","6d",
"d7","d9","cb","c5","ef","e1","f3","fd","a7","a9","bb","b5","9f","91","83","8d"};

        private void PagrindisLangas_Load(object sender, EventArgs e)
        {
            ZinuteTextBox.Text = message;
            keyTextBox.Text = key;
        }

        //-----------Uzsifravimas------------------------------------------------------------------------------
        private void btnUzkoduoti_Click(object sender, EventArgs e)
        {
            txtBoxAtkoduota.Text = "";

            message = ZinuteTextBox.Text;
            key = keyTextBox.Text;
            if (message.Length == 16 && key.Length == 16) uzkoduojam();
            else MessageBox.Show("Žinutės ir rakto ilgis turi būti po 16 simbolių!");
        }

        private void uzkoduojam()
        {
            char[] orgTextSplit = message.ToCharArray();
            string[] orgText16hex = new string[16];

            char[] orgKeySplit = key.ToCharArray();
            string[] orgKey16hex = new string[16];

            for (int i = 0; i < 16; i++)
            {
                orgText16hex[i] = Convert.ToByte(orgTextSplit[i]).ToString("x2");
                orgKey16hex[i] = Convert.ToByte(orgKeySplit[i]).ToString("x2");
            }

            txtUzkoduota.Text = AESbox(orgText16hex, orgKey16hex).ToUpper();
            btnAtkoduoti.Enabled = true;
        }
        private string AESbox(string[] orgText16hex, string[] orgKey16hex)
        {
            List<string[]> keys44 = generateKeys(orgKey16hex);
            string[] roundoRezultatas = sifrPridedamRound0Key(keys44, orgText16hex);

            for (int rr=1; rr<11; rr++)
            {
                //keiciam baitus
                for (int i=0; i<16; i++)
                {
                    char[] cS = roundoRezultatas[i].ToCharArray();

                    int x = int.Parse(cS[0].ToString(), System.Globalization.NumberStyles.HexNumber);
                    int y = int.Parse(cS[1].ToString(), System.Globalization.NumberStyles.HexNumber);

                    roundoRezultatas[i] = sBox[x, y];
                }

                //stumiam eilutes
                string[] ShiftedStateArray = { roundoRezultatas[0], roundoRezultatas[5], roundoRezultatas[10], roundoRezultatas[15], roundoRezultatas[4], roundoRezultatas[9], roundoRezultatas[14], roundoRezultatas[3],
                roundoRezultatas[8], roundoRezultatas[13], roundoRezultatas[2], roundoRezultatas[7], roundoRezultatas[12], roundoRezultatas[1], roundoRezultatas[6], roundoRezultatas[11] };

                //maisom stulpelius iki 9
                string[,] MixedStateArray = sifrMaisomStulpelius(rr, ShiftedStateArray);

                //pridedam round key
                roundoRezultatas = sifrPridedamRoundKey(rr, keys44, MixedStateArray);
            }

            //rezultatas----------------------------------------------------------------------------------
            string uzkoduotaTxt = "";
            for (int r = 0; r < 16; r++)
            {
                uzkoduotaTxt += roundoRezultatas[r];
            }

            return uzkoduotaTxt;
        }

        private string[] sifrPridedamRound0Key(List<string[]> keys44, string[] roundoRezultatas)
        {
            string[][] roundKey0 = new string[4][];
            for (int m = 0; m < 4; m++)
            {
                roundKey0[m] = keys44[m];
            }
            string[] key0 = new string[16];
            int count = 0;
            for (int a = 0; a < 4; a++)
            {
                for (int b = 0; b < 4; b++)
                {
                    key0[count] = roundKey0[a][b];
                    count += 1;
                }
            }

            for (int el = 0; el < 16; el++)
            {
                roundoRezultatas[el] = Convert.ToString(Convert.ToInt32(roundoRezultatas[el], 16) ^ Convert.ToInt32(key0[el], 16), 16).PadLeft(2, '0');
            }

            return roundoRezultatas;
        }
        private string[,] sifrMaisomStulpelius(int rr, string[] ShiftedStateArray)
        {
            string[,] MixedStateArray = new string[4, 4];
            if (rr < 10)
            {

                for (int m = 0; m < 4; m++)
                {
                    int b0 = Convert.ToInt32(ShiftedStateArray[m * 4], 16);
                    int b5 = Convert.ToByte(ShiftedStateArray[m * 4 + 1], 16);
                    int b10 = Convert.ToByte(ShiftedStateArray[m * 4 + 2], 16);
                    int b15 = Convert.ToByte(ShiftedStateArray[m * 4 + 3], 16);

                    string c0 = Convert.ToString((Convert.ToInt32(langelisKartDu(ShiftedStateArray[m * 4]), 16) ^ (Convert.ToInt32(langelisKartDu(ShiftedStateArray[m * 4 + 1]), 16) ^ b5) ^ b10 ^ b15), 16);
                    string c1 = Convert.ToString((b0 ^ (Convert.ToInt32(langelisKartDu(ShiftedStateArray[m * 4 + 1]), 16)) ^ (Convert.ToInt32(langelisKartDu(ShiftedStateArray[m * 4 + 2]), 16) ^ b10) ^ b15), 16);
                    string c2 = Convert.ToString((b0 ^ b5 ^ (Convert.ToInt32(langelisKartDu(ShiftedStateArray[m * 4 + 2]), 16)) ^ (Convert.ToInt32(langelisKartDu(ShiftedStateArray[m * 4 + 3]), 16) ^ b15)), 16);
                    string c3 = Convert.ToString(((Convert.ToInt32(langelisKartDu(ShiftedStateArray[m * 4]), 16) ^ b0) ^ b5 ^ b10 ^ (Convert.ToInt32(langelisKartDu(ShiftedStateArray[m * 4 + 3]), 16))), 16);

                    MixedStateArray[0, m] = c0.PadLeft(2, '0');
                    MixedStateArray[1, m] = c1.PadLeft(2, '0');
                    MixedStateArray[2, m] = c2.PadLeft(2, '0');
                    MixedStateArray[3, m] = c3.PadLeft(2, '0');
                }
            }
            else
            {
                int ind = 0;
                for (int eil = 0; eil < 4; eil++)
                {
                    for (int stulp = 0; stulp < 4; stulp++)
                    {
                        MixedStateArray[stulp, eil] = ShiftedStateArray[ind];
                        ind += 1;
                    }
                }
            }

            return MixedStateArray;
        }
        private string[] sifrPridedamRoundKey(int rr, List<string[]> keys44, string[,] MixedStateArray)
        {
            string[,] roundKey = new string[4, 4];
            for (int m = 0; m < 4; m++)
            {
                string[] temp = keys44[rr * 4 + m];
                roundKey[0, m] = temp[0];
                roundKey[1, m] = temp[1];
                roundKey[2, m] = temp[2];
                roundKey[3, m] = temp[3];
            }
            string[,] tarpineMatrica = new string[4, 4];
            for (int eil = 0; eil < 4; eil++)
            {
                for (int stulp = 0; stulp < 4; stulp++)
                {
                    tarpineMatrica[eil, stulp] = Convert.ToString(Convert.ToInt32(MixedStateArray[eil, stulp], 16) ^ Convert.ToInt32(roundKey[eil, stulp], 16), 16).PadLeft(2, '0');
                }
            }

            string[] roundoRezultatas = new string[16];
            int cci = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    roundoRezultatas[cci] = tarpineMatrica[j, i];
                    cci += 1;
                }
            }

            return roundoRezultatas;
        }
        public string langelisKartDu(string x)
        {
            string ats;
            string bitaiS = Convert.ToString(Convert.ToInt32(x, 16), 2).PadLeft(8, '0');
            char[] bitaiC = bitaiS.ToCharArray();
            string pastumti = bitaiC[1].ToString() + bitaiC[2].ToString() + bitaiC[3].ToString() + bitaiC[4].ToString() + bitaiC[5].ToString() + bitaiC[6].ToString() + bitaiC[7].ToString() + "0";

            var a = Convert.ToInt32(pastumti, 2);
            var b = Convert.ToInt32("00011011", 2);

            if (bitaiC[0] == '1')
            {
                ats = Convert.ToString((a ^ b), 16);
            }
            else
            {
                ats = Convert.ToString(a, 16);
            }

            return ats;
        }


        //----------44 rakto zodziu sukurimas------------------------------------------------------------------

        public List<string[]> generateKeys(string[] orgKey16hex)
        {
            List<string[]> keys44 = new List<string[]>();

            string[] w0 = { orgKey16hex[0], orgKey16hex[1], orgKey16hex[2], orgKey16hex[3] };
            string[] w1 = { orgKey16hex[4], orgKey16hex[5], orgKey16hex[6], orgKey16hex[7] };
            string[] w2 = { orgKey16hex[8], orgKey16hex[9], orgKey16hex[10], orgKey16hex[11] };
            string[] w3 = { orgKey16hex[12], orgKey16hex[13], orgKey16hex[14], orgKey16hex[15] };

            keys44.Add(w0);
            keys44.Add(w1);
            keys44.Add(w2);
            keys44.Add(w3);

            int counter = 0;
            int RCcounter = 0;
            for(int i=4; i<44; i++)
            {
                counter += 1;
                
                if (counter == 1)
                {
                    string[] wg = funkcijaG(RCcounter, keys44[i - 1]);
                    string[] w = fXor(wg, keys44[i - 4]);
                    keys44.Add(w);
                }
                else
                {
                    string[] w = fXor(keys44[i - 1], keys44[i - 4]);
                    keys44.Add(w);
                }

                if (counter == 4)
                {
                    counter = 0;
                    RCcounter += 1;
                }
            }

            return keys44;
        }
        public string[] funkcijaG(int RCcounter, string[] w)
        {
            string[] temp = {w[1],w[2],w[3],w[0]};
            for(int i=0; i<4; i++)
            {
                char[] cS = temp[i].ToCharArray();

                int x = int.Parse(cS[0].ToString(), System.Globalization.NumberStyles.HexNumber);
                int y = int.Parse(cS[1].ToString(), System.Globalization.NumberStyles.HexNumber);

                temp[i] = sBox[x,y];
            }

            temp[0] = Convert.ToString(Convert.ToInt32(temp[0], 16) ^ Convert.ToInt32(RC[RCcounter], 16), 16);

            return temp;
        }
        public string[] fXor(string[] x, string[] y)
        {
            string[] temp = new string[4];
            for (int i = 0; i < 4; i++)
            {
                temp[i] = Convert.ToString(Convert.ToInt32(x[i], 16) ^ Convert.ToInt32(y[i], 16), 16).PadLeft(2, '0');
            }
            return temp;
        }

        //-----------Desifravimas------------------------------------------------------------------------------
        private void btnAtkoduoti_Click(object sender, EventArgs e)
        {
            txtBoxAtkoduota.Text = desifravimas();
            btnAtkoduoti.Enabled = false;
        }

        public string desifravimas()
        {
            char[] uzkoduotaSplit = txtUzkoduota.Text.ToCharArray();
            string[] uzkoduota16hex = new string[16];

            char[] keySplit = key.ToCharArray();
            string[] key16hex = new string[16];

            for (int i = 0; i < 16; i++)
            {
                uzkoduota16hex[i] = uzkoduotaSplit[i*2].ToString() + uzkoduotaSplit[i*2+1].ToString();
                key16hex[i] = Convert.ToString(keySplit[i], 16);
            }
            //-----------------------------------------------------------------------------------------------------------------

            List<string[]> keys44 = generateKeys(key16hex);
            string[] roundoRezultatas = desifPridedamRound0Key(keys44, uzkoduota16hex);

            int kiekLikoKey = 39;
            for (int roundas = 1; roundas < 11; roundas++)
            {
                string[,] perstumtaMatrix = desifPerstumiamEilutes(roundoRezultatas);
                string[,] pakeistaMatrix = desifPakeiciamBaitus(perstumtaMatrix);
                string[,] pridetaRoundKeyMatrix = desifrPridedamRoundKey(keys44, pakeistaMatrix, kiekLikoKey);
                kiekLikoKey -= 4;

                string[,] MixedStateArray = new string[4, 4];
                if (roundas < 10) MixedStateArray = desifrMaisomStulpelius(pridetaRoundKeyMatrix);
                else MixedStateArray = pridetaRoundKeyMatrix;

                //-----------------------------------------------------------------------------------------------------------------
                int index = 0;
                for (int stulp = 0; stulp < 4; stulp++)
                {
                    for (int eil = 0; eil < 4; eil++)
                    {
                        roundoRezultatas[index] = MixedStateArray[eil, stulp];
                        index += 1;
                    }
                }
            }
            //-----------------------------------------------------------------------------------------------------------------

            string rezultatas = "";
            for (int i = 0; i < 16; i++)
            {
                rezultatas += roundoRezultatas[i];
            }
            string res = "";
            for (int a = 0; a < rezultatas.Length; a = a + 2)
            {
                string Char2Convert = rezultatas.Substring(a, 2);
                int n = Convert.ToInt32(Char2Convert, 16);
                char c = (char)n;
                res += c.ToString();
            }

            return res;
        }

        private string[] desifPridedamRound0Key(List<string[]> keys44, string[] roundoRezultatas)
        {
            string[][] roundKey4043 = new string[4][];
            for (int m = 0; m < 4; m++)
            {
                roundKey4043[m] = keys44[m + 40];
            }
            string[] key4043 = new string[16];
            int count = 0;
            for (int a = 0; a < 4; a++)
            {
                for (int b = 0; b < 4; b++)
                {
                    key4043[count] = roundKey4043[a][b];
                    count += 1;
                }
            }

            for (int el = 0; el < 16; el++)
            {
                roundoRezultatas[el] = Convert.ToString(Convert.ToInt32(roundoRezultatas[el], 16) ^ Convert.ToInt32(key4043[el], 16), 16).PadLeft(2, '0');
            }

            return roundoRezultatas;
        }
        private string[,] desifPerstumiamEilutes(string[] roundoRezultatas)
        {
            string[,] gautaMatrix = new string[4, 4];
            int counter = 0;
            for (int stulp = 0; stulp < 4; stulp++)
            {
                for (int eil = 0; eil < 4; eil++)
                {
                    gautaMatrix[eil, stulp] = roundoRezultatas[counter];
                    counter += 1;
                }
            }

            string[,] perstumtaMatrix = new string[4, 4];
            perstumtaMatrix[0, 0] = gautaMatrix[0, 0];
            perstumtaMatrix[0, 1] = gautaMatrix[0, 1];
            perstumtaMatrix[0, 2] = gautaMatrix[0, 2];
            perstumtaMatrix[0, 3] = gautaMatrix[0, 3];

            perstumtaMatrix[1, 0] = gautaMatrix[1, 3];
            perstumtaMatrix[1, 1] = gautaMatrix[1, 0];
            perstumtaMatrix[1, 2] = gautaMatrix[1, 1];
            perstumtaMatrix[1, 3] = gautaMatrix[1, 2];

            perstumtaMatrix[2, 0] = gautaMatrix[2, 2];
            perstumtaMatrix[2, 1] = gautaMatrix[2, 3];
            perstumtaMatrix[2, 2] = gautaMatrix[2, 0];
            perstumtaMatrix[2, 3] = gautaMatrix[2, 1];

            perstumtaMatrix[3, 0] = gautaMatrix[3, 1];
            perstumtaMatrix[3, 1] = gautaMatrix[3, 2];
            perstumtaMatrix[3, 2] = gautaMatrix[3, 3];
            perstumtaMatrix[3, 3] = gautaMatrix[3, 0];

            return perstumtaMatrix;
        }
        private string[,] desifPakeiciamBaitus(string[,] perstumtaMatrix)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    char[] cS = perstumtaMatrix[i, j].ToCharArray();

                    int x = int.Parse(cS[0].ToString(), System.Globalization.NumberStyles.HexNumber);
                    int y = int.Parse(cS[1].ToString(), System.Globalization.NumberStyles.HexNumber);

                    perstumtaMatrix[i, j] = inverseSbox[x, y];
                }
            }
            return perstumtaMatrix;
        }
        private string[,] desifrPridedamRoundKey(List<string[]> keys44, string[,] pakeistaMatrix, int kiekLikoKey)
        {
            string[,] AddedKeyStateArray = new string[4, 4];

            string[,] roundKey = new string[4, 4];
            for (int k = 0; k < 4; k++)
            {
                int temp = 3 - k;
                string[] keyTemp = keys44[kiekLikoKey - temp];
                roundKey[0, k] = keyTemp[0];
                roundKey[1, k] = keyTemp[1];
                roundKey[2, k] = keyTemp[2];
                roundKey[3, k] = keyTemp[3];
            }

            for (int eil = 0; eil < 4; eil++)
            {
                for (int stulp = 0; stulp < 4; stulp++)
                {
                    AddedKeyStateArray[eil, stulp] = Convert.ToString(Convert.ToInt32(pakeistaMatrix[eil, stulp], 16) ^ Convert.ToInt32(roundKey[eil, stulp], 16), 16).PadLeft(2, '0');
                }
            }

            return AddedKeyStateArray;
        }
        private string[,] desifrMaisomStulpelius(string[,] pridetaRoundKeyMatrix)
        {
            string[,] MixedStateArray = new string[4, 4];

            for (int m = 0; m < 4; m++)
            {
                int b0 = Convert.ToInt32(pridetaRoundKeyMatrix[0, m], 16);
                int b5 = Convert.ToInt32(pridetaRoundKeyMatrix[1, m], 16);
                int b10 = Convert.ToInt32(pridetaRoundKeyMatrix[2, m], 16);
                int b15 = Convert.ToInt32(pridetaRoundKeyMatrix[3, m], 16);

                string c0 = Convert.ToString(Convert.ToInt32(mc14[b0], 16) ^ Convert.ToInt32(mc11[b5], 16) ^ Convert.ToInt32(mc13[b10], 16) ^ Convert.ToInt32(mc9[b15], 16), 16);
                string c5 = Convert.ToString(Convert.ToInt32(mc9[b0], 16) ^ Convert.ToInt32(mc14[b5], 16) ^ Convert.ToInt32(mc11[b10], 16) ^ Convert.ToInt32(mc13[b15], 16), 16);
                string c10 = Convert.ToString(Convert.ToInt32(mc13[b0], 16) ^ Convert.ToInt32(mc9[b5], 16) ^ Convert.ToInt32(mc14[b10], 16) ^ Convert.ToInt32(mc11[b15], 16), 16);
                string c15 = Convert.ToString(Convert.ToInt32(mc11[b0], 16) ^ Convert.ToInt32(mc13[b5], 16) ^ Convert.ToInt32(mc9[b10], 16) ^ Convert.ToInt32(mc14[b15], 16), 16);

                MixedStateArray[0, m] = c0.PadLeft(2, '0');
                MixedStateArray[1, m] = c5.PadLeft(2, '0');
                MixedStateArray[2, m] = c10.PadLeft(2, '0');
                MixedStateArray[3, m] = c15.PadLeft(2, '0');
            }

            return MixedStateArray;
        }
    }
}
