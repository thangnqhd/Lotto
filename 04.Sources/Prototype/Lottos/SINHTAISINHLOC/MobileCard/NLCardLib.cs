// Decompiled with JetBrains decompiler
// Type: MobileCard.NLCardLib
// Assembly: SINHTAISINHLOC, Version=6.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: 14ECBB60-AC76-4B86-9AB8-7862FB51126A
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\SINHTAISINHLOC.exe

using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography;
using System.Text;

namespace MobileCard
{
  public class NLCardLib
  {
    private string Merchant_Pass = "";

    private NLCardLib()
    {
    }

    public static ResponseInfo CardChage(RequestInfo info)
    {
      return NLCardLib.ParserResult(NLCardLib.HttpPost(info));
    }

    private static ResponseInfo ParserResult(string output)
    {
      ResponseInfo responseInfo = new ResponseInfo();
      string[] strArray = output.Split('|');
      if (strArray.Length == 13)
      {
        responseInfo.Errorcode = strArray[0];
        responseInfo.Message = NLCardLib.GetErrorMessage(responseInfo.Errorcode);
        responseInfo.Card_amount = strArray[10];
        responseInfo.Refcode = strArray[6];
        responseInfo.Transaction_amount = strArray[11];
        responseInfo.TransactionID = strArray[12];
      }
      else
      {
        responseInfo.Errorcode = "99";
        responseInfo.Message = "Lỗi không xác định.";
      }
      return responseInfo;
    }

    private static string GetErrorMessage(string _ErrorCode)
    {
      string str = "";
      switch (_ErrorCode)
      {
        case "00":
          str = "Giao dịch thành công";
          break;
        case "01":
          str = "Lỗi, địa chỉ IP truy cập API của NgânLượng.vn bị từ chối";
          break;
        case "02":
          str = "Lỗi, tham số gửi từ merchant tới NgânLượng.vn chưa chính xác.";
          break;
        case "03":
          str = "Lỗi, mã merchant không tồn tại hoặc merchant đang bị khóa kết nối tới NgânLượng.vn";
          break;
        case "04":
          str = "Lỗi, mã checksum không chính xác";
          break;
        case "05":
          str = "Tài khoản nhận tiền nạp của merchant không tồn tại";
          break;
        case "06":
          str = "Tài khoản nhận tiền nạp của  merchant đang bị khóa hoặc bị phong tỏa, không thể thực hiện được giao dịch nạp tiền";
          break;
        case "07":
          str = "Thẻ đã được sử dụng";
          break;
        case "08":
          str = "Thẻ bị khóa";
          break;
        case "09":
          str = "Thẻ hết hạn sử dụng";
          break;
        case "10":
          str = "Thẻ chưa được kích hoạt hoặc không tồn tại";
          break;
        case "11":
          str = "Mã thẻ sai định dạng";
          break;
        case "12":
          str = "Sai số serial của thẻ";
          break;
        case "13":
          str = "Mã thẻ và số serial không khớp";
          break;
        case "14":
          str = "Thẻ không tồn tại";
          break;
        case "15":
          str = "Thẻ không sử dụng được";
          break;
        case "16":
          str = "Số lần thử của thẻ vượt quá giới hạn cho phép";
          break;
        case "17":
          str = "Máy chủ nạp thẻ đang bảo trì, thẻ chưa bị trừ";
          break;
        case "18":
          str = "Máy chủ nạp thẻ đang bảo trì, thẻ có thể bị trừ, cần phối hợp với NgânLượng để đối soát";
          break;
        case "19":
          str = "Máy chủ nạp thẻ đang bảo trì, thẻ chưa bị trừ.";
          break;
        case "20":
          str = "Kết nối tới Telco thành công, thẻ bị trừ nhưng chưa cộng tiền trên NgânLượng.vn";
          break;
        case "99":
          str = "Lỗi tuy nhiên lỗi chưa được định nghĩa hoặc chưa xác định được nguyên nhân";
          break;
      }
      return str;
    }

    private static string CreateMD5Hash(string input)
    {
      byte[] hash = MD5.Create().ComputeHash(Encoding.ASCII.GetBytes(input));
      StringBuilder stringBuilder = new StringBuilder();
      for (int index = 0; index < hash.Length; ++index)
        stringBuilder.Append(hash[index].ToString("x2"));
      return stringBuilder.ToString();
    }

    private static string GetParamPost(RequestInfo info)
    {
      return "" + "func=" + info.Funtion + "&version=" + info.Version + "&merchant_id=" + info.Merchant_id + "&merchant_account=" + info.Merchant_acount + "&merchant_password=" + NLCardLib.CreateMD5Hash(info.Merchant_id + "|" + info.Merchant_password) + "&pin_card=" + info.Pincard + "&card_serial=" + info.SerialCard + "&type_card=" + info.CardType + "&ref_code=" + info.Refcode + "&client_fullname=" + info.Client_fullname + "&client_email=" + info.Client_email + "&client_mobile=" + info.Client_mobile;
    }

    private static string HttpPost(RequestInfo request)
    {
      ServicePointManager.ServerCertificateValidationCallback = (RemoteCertificateValidationCallback) ((_param1, _param2, _param3, _param4) => true);
      byte[] bytes = new ASCIIEncoding().GetBytes(NLCardLib.GetParamPost(request));
      HttpWebRequest httpWebRequest = (HttpWebRequest) WebRequest.Create("https://www.nganluong.vn/mobile_card.api.post.v2.php");
      httpWebRequest.Method = "POST";
      httpWebRequest.ContentType = "application/x-www-form-urlencoded";
      httpWebRequest.ContentLength = (long) bytes.Length;
      Stream requestStream = httpWebRequest.GetRequestStream();
      requestStream.Write(bytes, 0, bytes.Length);
      requestStream.Close();
      HttpWebResponse response = (HttpWebResponse) httpWebRequest.GetResponse();
      string end = new StreamReader(response.GetResponseStream()).ReadToEnd();
      response.Close();
      return end;
    }
  }
}
