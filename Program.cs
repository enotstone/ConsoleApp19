using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp19
{
    class Program
    {
        class Comp
        {
            public int Id { get; set; }
            public string NComp { get; set; }
            public string TCPU { get; set; }
            public int FCPU { get; set; }
            public int VMem { get; set; }
            public string VHDD { get; set; }
            public int VVMem { get; set; }
            public int CComp { get; set; }
            public int AmtC { get; set; }


            public void Fulling(Random rnd)
            {

                //int value = rnd.Next(1, 10);
                TCPU = (rnd.Next(1, 10) < 5) ? "AMD" : (rnd.Next(1, 10) >= 5 && rnd.Next(1, 10) <= 8) ? "Elbrus" : "Intel";

                FCPU = (rnd.Next(1, 10) < 5) ? 1666 : (rnd.Next(1, 10) >= 5 && rnd.Next(1, 10) <= 8) ? 2555 : 3444;

                VMem = (rnd.Next(1, 10) < 5) ? 4096 : (rnd.Next(1, 10) >= 5 && rnd.Next(1, 10) <= 8) ? 8128 : 16256;

                VHDD = (rnd.Next(1, 10) < 5) ? "150Gb" : (rnd.Next(1, 10) >= 5 && rnd.Next(1, 10) <= 8) ? "500Gb" : "1Tb";

                VVMem = (rnd.Next(1, 10) < 5) ? 2048 : (rnd.Next(1, 10) >= 5 && rnd.Next(1, 10) <= 8) ? 4096 : 8128;
                NComp = Convert.ToString($"Name CPU: {TCPU}- freq. {FCPU}");
                CComp = rnd.Next(25000, 100000);
                AmtC = rnd.Next(5, 90);
                rnd = null;
            }
        }
        static void Main()   
        {
            Random rnd = new Random();
            int MaxId = 10;
            int i = 0;
            List<Comp> LComp = new List<Comp>(MaxId) { };
            
            do {
                Comp NewComp = new Comp();
                NewComp.Fulling(rnd);
                NewComp.Id = i+1;
                LComp.Add(NewComp);
                i++;
            } while (i < MaxId);
            foreach (Comp d in LComp)
            Console.WriteLine("{0,2} {1,6} {2,4} {3,5} {4,5} {5,4} {6,7:### ###}.00 {7,2} {8,22}", d.Id, d.TCPU, d.FCPU, d.VMem, d.VHDD, d.VVMem, d.CComp, d.AmtC, d.NComp);
            Console.WriteLine();

            Console.WriteLine("Input name processor: Elbrus, Intel, AMD.");
            string proc = Console.ReadLine();
            List<Comp> ProcType = (from ListP in LComp where ListP.TCPU == proc select ListP).ToList();
            foreach (Comp ListP in ProcType)
                Console.WriteLine("{0,2} {1,6} {2,4} {3,5} {4,5} {5,4} {6,7:### ###}.00 {7,2} {8,22}", ListP.Id, ListP.TCPU, ListP.FCPU, ListP.VMem, ListP.VHDD, ListP.VVMem, ListP.CComp, ListP.AmtC, ListP.NComp);
            Console.WriteLine();

            Console.WriteLine("Input V minimum memory (maximum 16256):");
            int vm = Convert.ToInt32(Console.ReadLine());
            List<Comp> VMem = (from Lvm in LComp where Lvm.VMem >= vm select Lvm).ToList();
            foreach (Comp Lvm in VMem)
                Console.WriteLine("{0,2} {1,6} {2,4} V.memory {3,5} {4,5} {5,4} {6,7:### ###}.00 {7,2} {8,22}", Lvm.Id, Lvm.TCPU, Lvm.FCPU, Lvm.VMem, Lvm.VHDD, Lvm.VVMem, Lvm.CComp, Lvm.AmtC, Lvm.NComp);
            Console.WriteLine();

            //List<Comp> Slist = (from d in LComp orderby d.CComp select d).ToList();
            //foreach (Comp d in Slist)
            //    Console.WriteLine("{0,2} {1,6} {2,4} {3,5} {4,5} {5,4} {6,7:### ###}.00 {7,2} {8,22}", d.Id, d.TCPU, d.FCPU, d.VMem, d.VHDD, d.VVMem, d.CComp, d.AmtC, d.NComp);
            //Console.WriteLine();

            List<Comp> SPlist = (from d in LComp orderby d.TCPU select d).ToList();
            foreach (Comp d in SPlist)
                Console.WriteLine("{0,2} CPU Name {1,6} {2,4} {3,5} {4,5} {5,4} {6,7:### ###}.00 {7,2} {8,22}", d.Id, d.TCPU, d.FCPU, d.VMem, d.VHDD, d.VVMem, d.CComp, d.AmtC, d.NComp);
            Console.WriteLine();

            List<Comp> SClist = (from d in LComp
                                 orderby d.CComp
                                 //where d.CComp.Min()
                                 select d).ToList();
            foreach (Comp d in SClist)
                Console.WriteLine("{0,2} {1,6} {2,4} {3,5} {4,5} {5,4} Sort Cost {6,7:### ###}.00 {7,2} {8,22}", d.Id, d.TCPU, d.FCPU, d.VMem, d.VHDD, d.VVMem, d.CComp, d.AmtC, d.NComp);
            Console.WriteLine();


            //var d = LComp.Min();  //LComp.Where(x => x % 2 == 0).Min();
            //List<Comp> SCl = (from d in SClist
            //                   //where d.First
            //                   //where d.Last
            //                   select d).ToList();



            //IEnumerable<Comp> SClist = LComp
            //    .Where(dM dM.CComp.Min()).ToList();
            //foreach (Comp d in SClist)

            var dM = SClist[0];
            Console.WriteLine("{0,2} {1,6} {2,4} {3,5} {4,5} {5,4} Min Cost {6,7:### ###}.00 {7,2} {8,22}", dM.Id, dM.TCPU, dM.FCPU, dM.VMem, dM.VHDD, dM.VVMem, dM.CComp, dM.AmtC, dM.NComp);
            dM = SClist[9];
            Console.WriteLine("{0,2} {1,6} {2,4} {3,5} {4,5} {5,4} Max Cost {6,7:### ###}.00 {7,2} {8,22}", dM.Id, dM.TCPU, dM.FCPU, dM.VMem, dM.VHDD, dM.VVMem, dM.CComp, dM.AmtC, dM.NComp);
            Console.WriteLine();

            
            List<Comp> Mc = (from d in LComp where d.AmtC >= 30 select d).ToList();
            foreach (Comp d in Mc)
                Console.WriteLine("{0,2} {1,6} {2,4} {3,5} {4,5} {5,4} {6,7:### ###}.00 amount > 30 {7,2} {8,22}", d.Id, d.TCPU, d.FCPU, d.VMem, d.VHDD, d.VVMem, d.CComp, d.AmtC, d.NComp);
            Console.WriteLine();



            Console.ReadKey();

        }

    }
}



/*
//
if (a > b)
{
result = "a is greater than b";
}
else if (a < b)
{
result = "b is greater than a";
}
else
{
result = "a is equal to b";
}
//
=
//
result = a > b ? "a is greater than b" : a < b ? "b is greater than a" : "a is equal to b";

//
}
}*/
