using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using BussinessCoreLibrary;
using HtmlAgilityPack;

namespace SoKetQua
{
    public class ParseWebData
    {
        private string _siteUrl = "http://ketqua.net/xo-so-truyen-thong.php?ngay=";
        private const string Table_Result_Id = "result_tab_mb";
        private const string Td_Result_G0_Id = "rs_0_0";
        private const string Td_Result_G1_Id = "rs_1_0";
        private const string Td_Result_G2_0_Id = "rs_2_0";
        private const string Td_Result_G2_1_Id = "rs_2_1";
        private const string Td_Result_G3_0_Id = "rs_3_0";
        private const string Td_Result_G3_1_Id = "rs_3_1";
        private const string Td_Result_G3_2_Id = "rs_3_2";
        private const string Td_Result_G3_3_Id = "rs_3_3";
        private const string Td_Result_G3_4_Id = "rs_3_4";
        private const string Td_Result_G3_5_Id = "rs_3_5";
        private const string Td_Result_G4_0_Id = "rs_4_0";
        private const string Td_Result_G4_1_Id = "rs_4_1";
        private const string Td_Result_G4_2_Id = "rs_4_2";
        private const string Td_Result_G4_3_Id = "rs_4_3";
        private const string Td_Result_G5_0_Id = "rs_5_0";
        private const string Td_Result_G5_1_Id = "rs_5_1";
        private const string Td_Result_G5_2_Id = "rs_5_2";
        private const string Td_Result_G5_3_Id = "rs_5_3";
        private const string Td_Result_G5_4_Id = "rs_5_4";
        private const string Td_Result_G5_5_Id = "rs_5_5";
        private const string Td_Result_G6_0_Id = "rs_6_0";
        private const string Td_Result_G6_1_Id = "rs_6_1";
        private const string Td_Result_G6_2_Id = "rs_6_2";
        private const string Td_Result_G7_0_Id = "rs_7_0";
        private const string Td_Result_G7_1_Id = "rs_7_1";
        private const string Td_Result_G7_2_Id = "rs_7_2";
        private const string Td_Result_G7_3_Id = "rs_7_3";
        private const string Td_Nodes_Tags = "tbody/tr/td";

        public ParseWebData(string url)
        {
            _siteUrl = url;
            //dummy
            _siteUrl = "http://ketqua.net/xo-so-truyen-thong.php?ngay=04-09-2018";
        }
        public void Parsing()
        {
            string HTML = string.Empty;
            using (var wc = new WebClient())
            {
                HTML = wc.DownloadString(_siteUrl);
                Console.WriteLine(HTML);
            }
            var doc = new HtmlDocument();
            doc.LoadHtml(HTML);

            //Find result lotto table
            var table = doc.GetElementbyId(Table_Result_Id);
            var ketqua = GeTblKetqua(table);
        }

        private tblKetqua GeTblKetqua(HtmlNode table)
        {
            tblKetqua ketqua = new tblKetqua();

            //Get all cell
            var cells = table.SelectNodes(Td_Nodes_Tags);
            //Giai dac biet
            ketqua.G0 = GetCellValue(cells, Td_Result_G0_Id);
            //Giai nhat
            ketqua.G1 = GetCellValue(cells, Td_Result_G1_Id);
            //Giai nhi
            ketqua.G21 = GetCellValue(cells, Td_Result_G2_0_Id);
            ketqua.G22 = GetCellValue(cells, Td_Result_G2_1_Id);
            //Giai ba
            ketqua.G31 = GetCellValue(cells, Td_Result_G3_0_Id);
            ketqua.G32 = GetCellValue(cells, Td_Result_G3_1_Id);
            ketqua.G33 = GetCellValue(cells, Td_Result_G3_2_Id);
            ketqua.G34 = GetCellValue(cells, Td_Result_G3_3_Id);
            ketqua.G35 = GetCellValue(cells, Td_Result_G3_4_Id);
            ketqua.G36 = GetCellValue(cells, Td_Result_G3_5_Id);
            //Giai tu
            ketqua.G41 = GetCellValue(cells, Td_Result_G4_0_Id);
            ketqua.G42 = GetCellValue(cells, Td_Result_G4_1_Id);
            ketqua.G43 = GetCellValue(cells, Td_Result_G4_2_Id);
            ketqua.G44 = GetCellValue(cells, Td_Result_G4_3_Id);
            //Giai nam
            ketqua.G51 = GetCellValue(cells, Td_Result_G5_0_Id);
            ketqua.G52 = GetCellValue(cells, Td_Result_G5_1_Id);
            ketqua.G53 = GetCellValue(cells, Td_Result_G5_2_Id);
            ketqua.G54 = GetCellValue(cells, Td_Result_G5_3_Id);
            ketqua.G55 = GetCellValue(cells, Td_Result_G5_4_Id);
            ketqua.G56 = GetCellValue(cells, Td_Result_G5_5_Id);
            //Giai sau
            ketqua.G61 = GetCellValue(cells, Td_Result_G6_0_Id);
            ketqua.G62 = GetCellValue(cells, Td_Result_G6_1_Id);
            ketqua.G63 = GetCellValue(cells, Td_Result_G6_2_Id);
            //Giai bay
            ketqua.G71 = GetCellValue(cells, Td_Result_G7_0_Id);
            ketqua.G72 = GetCellValue(cells, Td_Result_G7_1_Id);
            ketqua.G73 = GetCellValue(cells, Td_Result_G7_2_Id);
            ketqua.G74 = GetCellValue(cells, Td_Result_G7_3_Id);

            return ketqua;
        }

        private string GetCellValue(HtmlNodeCollection cells, string idCell)
        {
            foreach (var cell in cells)
            {
                if (cell.Id == idCell)
                {
                    return cell.InnerText;
                }
            }

            return string.Empty;
        }
    }
}
