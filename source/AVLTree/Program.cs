using System;

namespace DoAn20880230
{
    class Program
    {        
              
        static void Main(string[] args)
        {            
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            int count = 102217;      
            Console.WriteLine("\tSố lượng từ điển chương trình hiện có 102.217 từ");
            Dictionary dict = BLL.InsertDictionary(count);
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("\t************************ Chào Mừng bạn đến với Từ Điển Anh - Anh ************************");
                Console.WriteLine("\t(1): Tìm Kiếm");
                Console.WriteLine("\t(2): In toàn bộ Từ điển ");
                Console.WriteLine("\t(3): Đo thời gian tìm kiếm trung bình");
                Console.WriteLine("\t(Số bất kỳ): Kết thúc chương trình");
                Console.Write("\tVui Lòng Nhập chức năng cần thực hiện: \t");
                int luachon = int.Parse(Console.ReadLine());
                switch (luachon)
                {
                    case 1:
                        BLL.Search(dict);
                        break;
                    case 2:
                        dict.print();
                        break;
                    case 3:
                        BLL.Searchcountword(dict);
                        break;
                    default:
                        dict.Clear();
                        Console.WriteLine("\t************** Xin chào ************");
                        return;
                }
            }                
        }
    }
}
