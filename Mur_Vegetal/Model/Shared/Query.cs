using System;
using System.IO;
using System.Net;
public partial class Query{
    public static string Get(string uri){
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
        request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            try{
                using(HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using(Stream stream = response.GetResponseStream())
                using(StreamReader reader = new StreamReader(stream)){
                    return reader.ReadToEnd();
                }
            }
            catch (WebException e){
                using (WebResponse response = e.Response)
                {
                    HttpWebResponse httpResponse = (HttpWebResponse) response;
                    Console.WriteLine("Error code: {0} when trying to GET {1}", httpResponse.StatusCode, uri);
                    using (Stream data = response.GetResponseStream())
                    using (var reader = new StreamReader(data)){
                        return reader.ReadToEnd();
                    }
                }
            }
            catch (Exception e) {  
                Console.WriteLine("Error: {0} when trying to GET {1}", e.InnerException.Message, uri);
                return e.InnerException.Message;
            }
    }
}