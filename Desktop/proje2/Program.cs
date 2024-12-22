using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // 7 elemanlı bir Generic List dizisi oluşturuluyor
        List<List<UM_Alanı>> umAlanlarıDizisi = new List<List<UM_Alanı>>();
        for (int i = 0; i < 7; i++)
        {
            umAlanlarıDizisi.Add(new List<UM_Alanı>());
        }



        // Hangi bölgelerde ise, ilgili bölgeler listesine ekleniyor (örnek olarak Akdeniz)


        List<List<string>> BölgelerVeİller = new List<List<string>>
        {
            new List<string> {"Marmara" ,"İstanbul" ,"Edirne" ,"Bursa","Çanakkale" },
            new List<string> {"İç Anadolu" ,"Sivas" ,"Nevşehir","Konya","Ankara","Eskişehir"  },
            new List<string> {"Doğu Anadolu" ,"Malatya" ,"Kars"  },
            new List<string> { "Güneydoğu Anadolu","Şanlıurfa" ,"Diyarbakır" ,"Adıyaman",},
            new List<string> {"Akdeniz" ,"Antalya-Muğla"},
            new List<string> {"Ege" ,"İzmir" ,"Denizli" ,"Aydın","Afyon" },
            new List<string> {"Karadeniz"  ,"Karabük","Kastamonu"  },
        };


        // Bölgelerin isimleri
        string[] Bölgeler = { "Marmara", "İç Anadolu", "Doğu Anadolu", "Güneydoğu Anadolu", "Akdeniz", "Ege", "Karadeniz" };


        string unescoSites = "Divriği Ulu Camii ve Darüşşifası (Sivas) 1985\n" +
            "İstanbul'un Tarihi Alanları (İstanbul) 1985\n" +
            "Göreme Millî Parkı ve Kapadokya (Nevşehir) 1985\n" +
            "Hattuşa: Hitit Başkenti (Çorum) 1986\n" +
            "Nemrut Dağı (Adıyaman) 1987\n" +
            "Hieropolis - Pamukkale(Denizli) 1988\n" +
            "Xanthos-Letoon (Antalya-Muğla) 1988\n" +
            "Safranbolu Şehri (Karabük) 1994\n" +
            "Truva Arkeolojik Alanı (Çanakkale) 1998\n" +
            "Edirne Selimiye Camii ve Külliyesi (Edirne) 2011\n" +
            "Çatalhöyük Neolitik Alanı (Konya) 2012\n" +
            "Bursa ve Cumalıkızık: Osmanlı İmparatorluğunun Doğuşu (Bursa) 2014\n" +
            "Bergama Çok Katmanlı Kültürel Peyzaj Alanı (İzmir) 2014\n" +
            "Diyarbakır Kalesi ve Hevsel Bahçeleri Kültürel Peyzajı (Diyarbakır) 2015\n" +
            "Efes (İzmir) 2015\n" +
            "Ani Arkeolojik Alanı (Kars) 2016\n" +
            "Aphrodisias (Aydın) 2017\n" +
            "Göbekli Tepe (Şanlıurfa) 2018\n" +
            "Arslantepe Höyüğü (Malatya) 2021\n" +
            "Gordion (Ankara) 2023\n"+
            "Eşrefoğlu Camii (Konya) 2023\n"+
            "Mahmut Bey Camii (Kastamonu) 2023\n" +
            "Sivrihisar Camii (Eskişehir) 2023\n" +
            "Afyon Ulu Camii (Afyon) 2023\n" +
            "Arslanhane Camii (Ankara) 2023" 
            ;




        UM_Alanı ParseSiteInfo(string siteInfo)
        {
            string[] parts = siteInfo.Split(new[] {"(", ")"}, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length >= 3)
            {
                string alanAdı = parts[0];
                List<string> ilAdları = new List<string> { parts[1] };
                int ilanYılı;
                if (int.TryParse(parts[2], out ilanYılı))
                {
                    return new UM_Alanı(alanAdı, ilAdları, ilanYılı);
                }
            }
            // If parsing fails, return null
            return null;
        }





        string[] unescoSiteLines = unescoSites.Split('\n', (char)StringSplitOptions.RemoveEmptyEntries);
        foreach (string siteInfo in unescoSiteLines)
        {
            UM_Alanı alan = ParseSiteInfo(siteInfo);
            string ilAdı = alan.İl_Adları[0];
            for(int i = 0;i< BölgelerVeİller.Count;i++)
            {
                for (int j = 0; j < BölgelerVeİller[i].Count; j++)
                {
                    if (BölgelerVeİller[i][j] == ilAdı)
                    {
                        umAlanlarıDizisi[i].Add(alan);
                    }
                }
            }        
                
                    
         }

        // Diğer UM_Alanı örnekleri ve bölgeler ekleme işlemleri buraya eklenir...

        // Verileri kullanma
        for (int i = 0; i < umAlanlarıDizisi.Count; i++)
        {
            Console.WriteLine($"                       --- {Bölgeler[i]} --- \n\n");
            if (umAlanlarıDizisi[i] != null)
            {
                
                foreach (UM_Alanı alan in umAlanlarıDizisi[i])
                {
                    Console.WriteLine($"Alan Adı: {alan.Alan_Adı}");
                    Console.WriteLine($"İller: {string.Join(", ", alan.İl_Adları)}");
                    Console.WriteLine($"İlan Yılı: {alan.İlan_Yılı}");
                    Console.WriteLine();
                }

            }
            
            else
            {
                Console.WriteLine("Bölgede herhangi bir veri bulunmamaktadır.");
            }
        }
        for (int i = 0; i < umAlanlarıDizisi.Count; i++)
        {
            Console.WriteLine($"--- {Bölgeler[i]} bölgesindeki Miras Alanı sayısı: {umAlanlarıDizisi[i].Count}");
        }


        UM_AlanıStack umAlanıStack = new UM_AlanıStack();
        Console.WriteLine("Yığın (Stack) İşlemleri:");
        for (int i = 0; i < umAlanlarıDizisi.Count; i++)
        {
            if (umAlanlarıDizisi != null)
            {
                foreach (UM_Alanı alan in umAlanlarıDizisi[i])
                {

                    umAlanıStack.Push(alan);
                }
            }


            while (!umAlanıStack.IsEmpty())
            {
                UM_Alanı poppedAlan = umAlanıStack.Pop();
                Console.WriteLine($"Alan Adı: {poppedAlan.Alan_Adı}, İller: {string.Join(", ", poppedAlan.İl_Adları)}, İlan Yılı: {poppedAlan.İlan_Yılı}");
            }

            
        }
        Console.WriteLine("\nKuyruk (Queue) İşlemleri:");
        for (int i = 0; i < umAlanlarıDizisi.Count; i++)
        {
            // Kuyruk işlemleri (Queue operations)
            UM_AlanıQueue umAlanıQueue = new UM_AlanıQueue();
            foreach (UM_Alanı alan in umAlanlarıDizisi[i])
            {
                umAlanıQueue.Enqueue(alan);
            }

 
            while (!umAlanıQueue.IsEmpty())
            {
                UM_Alanı dequeuedAlan = umAlanıQueue.Dequeue();
                Console.WriteLine($"Alan Adı: {dequeuedAlan.Alan_Adı}, İller: {string.Join(", ", dequeuedAlan.İl_Adları)}, İlan Yılı: {dequeuedAlan.İlan_Yılı}");
            }


        }

        PriorityQueue<UM_Alanı> umAlanlarıPriorityQueue = new PriorityQueue<UM_Alanı>();

        for (int i = 0; i < umAlanlarıDizisi.Count; i++)
        {
            foreach (UM_Alanı alan in umAlanlarıDizisi[i])
            {
                umAlanlarıPriorityQueue.Enqueue(alan);
            }
        }

        Console.WriteLine("\nÖncelikli Kuyruk (PriorityQueue) İşlemleri (Alfabetik Sırayla):");

        while (!umAlanlarıPriorityQueue.IsEmpty())
        {
            UM_Alanı dequeuedItem = umAlanlarıPriorityQueue.Dequeue();
            Console.WriteLine($"Alan Adı: {dequeuedItem.Alan_Adı}, İller: {string.Join(", ", dequeuedItem.İl_Adları)}, İlan Yılı: {dequeuedItem.İlan_Yılı}");
        }

    }












    class UM_Alanı : IComparable<UM_Alanı>
    {
        public string Alan_Adı { get; set; }
        public List<string> İl_Adları { get; set; }
        public int İlan_Yılı { get; set; }

        public UM_Alanı(string alanAdı, List<string> ilAdları, int ilanYılı)
        {
            Alan_Adı = alanAdı;
            İl_Adları = ilAdları;
            İlan_Yılı = ilanYılı;
        }
        public int CompareTo(UM_Alanı other)
        {
            return this.Alan_Adı.CompareTo(other.Alan_Adı);
        }
    }



    class UM_AlanıStack
    {
        private Stack<UM_Alanı> stack = new Stack<UM_Alanı>();

        public void Push(UM_Alanı alan)
        {
            stack.Push(alan);
        }

        public UM_Alanı Pop()
        {
            return stack.Pop();
        }

        public bool IsEmpty()
        {
            return stack.Count == 0;
        }
    }

    class UM_AlanıQueue
    {
        private Queue<UM_Alanı> queue = new Queue<UM_Alanı>();

        public void Enqueue(UM_Alanı alan)
        {
            queue.Enqueue(alan);
        }

        public UM_Alanı Dequeue()
        {
            return queue.Dequeue();
        }

        public bool IsEmpty()
        {
            return queue.Count == 0;
        }
    }

    class PriorityQueue
    {
        private List<UM_Alanı> umAlanları;

        public PriorityQueue()
        {
            umAlanları = new List<UM_Alanı>();
        }

        public void Enqueue(UM_Alanı alan)
        {
            umAlanları.Add(alan);
        }

        public UM_Alanı Dequeue()
        {
            if (IsEmpty())
            {
                Console.WriteLine("PriorityQueue is empty. Cannot dequeue.");
                return null;
            }

            int minIndex = 0;
            for (int i = 1; i < umAlanları.Count; i++)
            {
                if (string.Compare(umAlanları[i].Alan_Adı, umAlanları[minIndex].Alan_Adı, StringComparison.Ordinal) < 0)
                {
                    minIndex = i;
                }
            }

            UM_Alanı minAlan = umAlanları[minIndex];
            umAlanları.RemoveAt(minIndex);
            return minAlan;
        }

        public bool IsEmpty()
        {
            return umAlanları.Count == 0;
        }
    }

    class PriorityQueue<T> where T : IComparable<T>
    {
        private List<T> items;

        public PriorityQueue()
        {
            items = new List<T>();
        }

        public void Enqueue(T item)
        {
            items.Add(item);
        }

        public T Dequeue()
        {
            if (IsEmpty())
            {
                Console.WriteLine("PriorityQueue is empty. Cannot dequeue.");
                return default(T);
            }

            int minIndex = 0;
            for (int i = 1; i < items.Count; i++)
            {
                if (items[i].CompareTo(items[minIndex]) < 0)
                {
                    minIndex = i;
                }
            }

            T minItem = items[minIndex];
            items.RemoveAt(minIndex);
            return minItem;
        }

        public bool IsEmpty()
        {
            return items.Count == 0;
        }
    }



}