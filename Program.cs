using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conversor_Binário
{
    class Program
    {
        static int Pow(int Base, int Power)
        {
            if(Power == 0)
            {
                return 1;
            }
            else
            {
                return Base * Pow(Base, --Power);
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Escolha uma opção:\n1. Binário - Decimal\n2. Decimal - Binário");
            int resposta = int.Parse(Console.ReadLine());

            if (resposta == 1)
            {


                Console.WriteLine("Digite o número na base binária");
                string num = Console.ReadLine();
                char[] número = num.ToCharArray();
                int númeroDecimal = 0;

                for (int i = número.Length - 1; i >= 0; i--)
                {
                    if (número[i] == '1')
                    {
                        númeroDecimal = númeroDecimal + Pow(2, ((número.Length - 1) - i));
                    }
                }

                Console.WriteLine("O número na base decimal é igual a: {0}", númeroDecimal);
            }
            else
            {
                Console.WriteLine("Digite o número na base decimal");
                int número = int.Parse(Console.ReadLine()), bits = 0;

                bool verificar = false;

                while (!verificar)
                {
                    if (número >= Pow(2, bits) && número < Pow(2, bits + 1))
                    {
                        verificar = true;
                    }
                    bits++;
                }
                int x = (bits - 1);
                char[] númeroBinário = new char[bits];

                for (int i = númeroBinário.Length - 1; i >= 0; i--)
                {
                    if(número >= Pow(2, i))
                    {
                        númeroBinário[-i + x] = '1';
                        número -= Pow(2, i);
                    }
                    else
                    {
                        númeroBinário[-i + x] = '0';
                    }
                }
                string númeroFinal = "";
                for (int i = 0; i < númeroBinário.Length; i++)
                {
                    númeroFinal += númeroBinário[i];
                }

                Console.WriteLine("O número na base binária é: {0}", númeroFinal);
            }

            Console.ReadKey();
        }
    }
}
