using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace UAS_066
{
    class Node
    {
        //deklarasi variabel
        public int idobat;
        public string namaobat;
        public string dosis;
        public string harga;
        public Node next;
    }
    class CircularLinkedList
    {
        Node LAST;
        public CircularLinkedList()
        {
            LAST = null;
        }
        //Method Menambahkan Data
        public void addnode()
        {
            int number;
            string nm;
            string dss;
            string hrg;

            Console.WriteLine("Masukkan Id Obat : ");
            number = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Masukkan Nama Obat : ");
            nm = Console.ReadLine();
            Console.WriteLine("Masukkan Dosis Obat : ");
            dss = Console.ReadLine();
            Console.WriteLine("Masukkan Harga Obat : ");
            hrg = Console.ReadLine();

            Node newnode = new Node();

            newnode.idobat = number;
            newnode.namaobat = nm;
            newnode.dosis = dss;
            newnode.harga = hrg;

            if (listempty())
            {
                newnode.next = newnode;
                LAST = newnode;
            }
            else if (number < LAST.next.idobat)
            {
                newnode.next = LAST.next;
                LAST.next = newnode;
            }
            else if (number > LAST.idobat)
            {
                newnode.next = LAST.next;
                LAST.next = newnode;
                LAST = newnode;
            }
            else
            {
                Node current, previous;
                current = previous = LAST.next;

                int i = 0;
                while (i < number - 1)
                {
                    previous = current;
                    current = current.next;
                    i++;
                }
                newnode.next = current;
                previous.next = newnode;
            }
        }
        //Method Mencari Data
        public bool Search(string dss, ref Node previous, ref Node current)
        {
            for (previous = current = LAST.next; current != LAST; previous = current, current = current.next)
            {
                if (dss == current.dosis)
                    return true;//return true if the node is found
            }
            if (dss == LAST.dosis)
                return true;
            else
                return (false);
        }
        //Method Menghapus Data
        public bool delNode(string namaobat)
        {
            Node previous, current;
            previous = current = LAST.next;

            //mengecek spesifikasi isi nod sekarang masih ada didalam list atau tidak
            if (Search(namaobat, ref previous, ref current) == false)
                return false;
            previous.next = current.next;

            //proses mendelete data
            if (LAST.next.idobat == LAST.idobat)
            {
                LAST.next = null;
                LAST = null;
            }
            else if (namaobat == LAST.namaobat)
            {
                LAST.next = current.next;
            }
            else
            {
                LAST = LAST.next;
            }
            return true;
        }
        public void display()
        {
            if (listempty())
                Console.WriteLine("\nList Kosong : ");
            else
            {
                Console.WriteLine("\nPencarian yang terkait adalah : ");
                Node currentNode;

                currentNode = LAST.next;
                while (currentNode != LAST)
                {
                    Console.Write(currentNode.idobat + " " + currentNode.namaobat + " " + currentNode.dosis + " " + currentNode.harga);
                    currentNode = currentNode.next;
                }
                Console.Write(LAST.idobat + " " + LAST.namaobat + " " + LAST.dosis + " " + currentNode.harga);
            }
        }
        public void firstnode()
        {
            if (listempty())
                Console.WriteLine("\nList kosong");
            else
                Console.WriteLine("\nUrutan pertama adalah :\n\n " + LAST.next.idobat + "   " + LAST.next.namaobat);
        }
        public bool listempty()
        {

            if (LAST == null)
                return true;
            else
                return false;
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Program menu = new Program();
            CircularLinkedList data = new CircularLinkedList();
            Node a = new Node();

            while (true)
            {
                try
                {
                    Console.WriteLine("--------------------------");
                    Console.WriteLine("------- PILIH MENU -------");
                    Console.WriteLine("--------------------------");
                    Console.WriteLine("1. Tambah Data");
                    Console.WriteLine("2. Hapus Data ");
                    Console.WriteLine("3. Cari Data ");
                    Console.WriteLine("4. Pengurutan Data ");
                    Console.WriteLine("5. Exit\n");
                    Console.WriteLine("Masukan Pilihan Anda ");
                    char ch = Convert.ToChar(Console.ReadLine());

                    switch (ch)
                    {
                        case '1':
                            {
                                data.addnode();
                            }
                            break;
                        case '2':
                            {
                                if (data.listempty())
                                {
                                    Console.WriteLine("\nList Kosong");
                                    break;
                                }
                                //pencarian node list yang akan didelete
                                Console.Write("\nMasukkan Data yang akan dihapus : ");
                                string value = Convert.ToString(Console.ReadLine());
                                Console.WriteLine();

                                //output data yang didelete node
                                if (data.delNode(value) == false)
                                    Console.WriteLine("\nData tidak ditemukan");
                                else
                                    Console.WriteLine("Data dengan No" + " " + value + " " + "dihapus dari list");
                            }
                            break;
                        case '3':
                            {
                                data.display();
                            }
                            break;
                        case '4':
                            {
                                data.firstnode();
                            }
                            break;
                        case '5':
                            return;
                        default:
                            {
                                Console.WriteLine("\nPilihan Salah");
                                Console.ReadKey();
                                break;
                            }
                    }
                }catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }
    }
}
 /* 2. Menggunakan Algoritma CircularLinkedList
       Karena algoritma ini dapat menggunakan method pencarian, mengurutkan dan menampilkan.
    3. Perbedaan dari Array dan LinkedList adalah 
       jika array ada pengulangan jika LnkedList tidak -> karena array dapat mengurutkan data dari yg terbesar dan terkecil
       jika LinkedList terdapat method search display yang dapat menginput data, menampilkan , dan menghapus data data yg kita inginkan berbeda dengan array
       Kapan kita harus menggunakan tipe data tersebut, dapat dilihat pada program yang kita buat butuhnya apa , jika terdapat method yang mamapu menghapus mencari data, dapat menggunakan LinkedList
       jika terdapat pengulangan dalam program lebih baik kita menggunakan Array
    4. add Front , delete Front (CircularQueues)
    5. a. 42,62,64
       b. InOrder ( 16,25,41,53,42,46,55,60,74,62,63,64,65,70 )
 */
      