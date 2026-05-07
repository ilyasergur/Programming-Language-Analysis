using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using System.Text;

namespace BIL240_Proje
{
    class File_IO
    {
        static void Main(string[] args)
        {
            string inputFile = "BIL240_proje_verisi_95mb.txt";
            string outputFile = "temiz_veri_cs.txt";

            Stopwatch sw = Stopwatch.StartNew();
            Process currentProcess = Process.GetCurrentProcess();

            HashSet<string> uniqueLines = new HashSet<string>();

            try
            {
                using (StreamReader reader = new StreamReader(inputFile, Encoding.UTF8))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        uniqueLines.Add(line);
                    }
                }

                using (StreamWriter writer = new StreamWriter(outputFile, false, Encoding.UTF8))
                {
                    foreach (var line in uniqueLines)
                    {
                        writer.WriteLine(line);
                    }
                }

                sw.Stop();

                long runtimeMs = sw.ElapsedMilliseconds;
                long peakMemoryMb = currentProcess.PeakWorkingSet64 / (1024 * 1024);

                Console.WriteLine("-----------------------------------------");
                Console.WriteLine($"Runtime: {runtimeMs} ms");
                Console.WriteLine($"Peak Memory Usage: {peakMemoryMb} MB");
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine("İşlem tamamlandı. Excel'e kaydedebilirsiniz.");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Hata: dosya bulunamadı!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Bir hata oluştu: " + e.Message);
            }
        }
    }
}