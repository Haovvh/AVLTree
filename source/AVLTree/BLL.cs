using System;
using System.IO;
using System.Collections;
using Newtonsoft.Json;

namespace DoAn20880230
{
    class BLL
    {
        public static Hashtable ReadHashtable()
        {
            // data == https://github.com/matthewreagan/WebstersEnglishDictionary                             
            StreamReader file = new StreamReader("../../../../../Data/data.json");
            string jsonData = file.ReadToEnd();
            file.Close();
            Hashtable dict = JsonConvert.DeserializeObject<Hashtable>(jsonData);
            Console.WriteLine($"\tNạp dữ liệu vào Dictionary hoàn thành");
            return dict;
        }
        public static void Search(Dictionary dict)
        {
            while (true)
            {
                Console.WriteLine("\t******************************************************************************************");
                Console.WriteLine("\tVui lòng nhập đúng từ cần tìm");
                Console.Write("\tTừ cần tìm:\t==>\t");
                string keyword = Console.ReadLine().ToLower();
                var watch = System.Diagnostics.Stopwatch.StartNew();
                string mean = dict.Search(keyword);
                if (dict.Search(keyword) == null)
                {
                    Console.WriteLine($"\tKhông tìm thấy {keyword} trong từ điển");
                    break;
                }
                else
                {
                    Console.WriteLine($"\t{keyword} \n\tNghĩa của từ: {mean}");
                }
                watch.Stop();
                var searchTime = watch.ElapsedMilliseconds;
                Console.WriteLine($"\tThời gian tìm kiếm của từ {keyword} là: {searchTime} ms");
                Console.WriteLine("\t******************************************************************************************");
                Console.WriteLine();
            }
        }

        public static Dictionary InsertDictionary(int N)
        {
            var data = ReadHashtable();
            int count = 0;
            Dictionary dictionary = new Dictionary();
            foreach (DictionaryEntry ds in data)
            {
                dictionary.Add(Convert.ToString(ds.Key), Convert.ToString(ds.Value));
                count++;
                if (count == N)
                {
                    break;
                }
            }
            Console.WriteLine($"\tThêm thành công {N} words vào Từ Điển ");
            return dictionary;
        }
        public static void Searchcountword(Dictionary dict)
        {
            Console.WriteLine();
            Console.WriteLine("\tChào mừng bạn đến với chức năng đo thời gian tìm kiếm trung bình từ ngẫu nhiên");            
            Console.Write("\tNhập số lượng từ cần đo thời gian tìm kiếm: ");
            int count = int.Parse(Console.ReadLine());
            if (count <= 0 || count > dict.Count)
            {
                Console.WriteLine("\tBạn đã nhập sai");
                return;
            }
            Random r = new Random();
            Console.WriteLine($"\tTìm kiếm {count} từ");            
            var watch = System.Diagnostics.Stopwatch.StartNew();
            while (count > 0)
            {
                int IDrandom = r.Next(0, dict.Count);
                string key = dict.ArrayKeys[IDrandom];
                dict.Search(key);
                count--;
            }
            watch.Stop();
            var searchTime = watch.ElapsedMilliseconds;
            Console.WriteLine($"\tThời gian tìm kiếm trung bình: {searchTime} ms");

        }
    }
}
