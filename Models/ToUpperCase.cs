using System.ComponentModel.DataAnnotations;

namespace BaiThucHanh1402.Models
{
    public class ToUpperCase
    {
        public string upperCase(string text){
            string textUpperCase = " ";
            string[] words = text.ToLower().Split(" ");            
            foreach(var item in words){
                textUpperCase +=item.Replace(item.Substring(0,1),item.Substring(0,1).ToUpper()) + " ";
            }
            return textUpperCase.Trim();
        }
    }
}