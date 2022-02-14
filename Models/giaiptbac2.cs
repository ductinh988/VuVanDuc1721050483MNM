using System;

namespace BaiThucHanh1402.Models {
    public class giaiptbac2 {
       
        public string giaiphuongtrinh2(double a, double b,double c)
        {
        
            double delta = b*b-4*a*c;
            if(delta < 0) {
                return "phương trình vô nghiệm";
            } else if( delta == 0){
                return $"Phương trình có nghiệp kép{-b/(2*a)}" ;
            }else {
                return $"Phương trình có 2 nghiệm{(-b+Math.Sqrt(delta))/2*a} và {(-b-Math.Sqrt(delta))/2*a} ";                
            }
        }
    }
    
}