//Escreva um programa que informa o valor por extenso, por exemplo:

//-Valor final da compra: 328,90
//- Output do programa: TREZENTOS E VINTE E OITO REAIS E NOVENTA CENTAVOS

// Listas de palavras para números de 0 a 999
string[] unidades = { "zero", "um", "dois", "três", "quatro", "cinco", "seis", "sete", "oito", "nove" };
string[] dezenas = { "", "", "vinte", "trinta", "quarenta", "cinquenta", "sessenta", "setenta", "oitenta", "noventa" };
string[] centenas = { "", "cem", "duzentos", "trezentos", "quatrocentos", "quinhentos", "seiscentos", "setecentos", "oitocentos", "novecentos" };

// Receber valor como entrada do usuário
Console.Write("Digite um valor final da compra: ");
double valor = double.Parse(Console.ReadLine());

// Separe o valor em parte inteira e decimal
int parteInteira = (int)valor;
string parteDecimal1 = ((valor - parteInteira) * 100).ToString("N0");
Int32 parteDecimal = Convert.ToInt32(parteDecimal1);

// Converta a parte inteira para sua forma por extenso
string valorPorExtenso;
if (parteInteira == 0)
{
    valorPorExtenso = "zero";
}
else
{
    string[] extenso = new string[3];
    if (parteInteira >= 100)
    {
        extenso[0] = centenas[parteInteira / 100];
        parteInteira %= 100;
        if (parteInteira == 0 && parteDecimal == 0)
        {
            extenso[1] = "de";
        }
        else if (parteInteira > 0)
        {
            extenso[1] = "e";
        }
    }
    if (parteInteira >= 20)
    {
        extenso[1] += " " + dezenas[parteInteira / 10];
        parteInteira %= 10;
        if (parteInteira > 0)
        {
            extenso[1] += " e";
        }
    }
    if (parteInteira > 0 || extenso[1] == null)
    {
        extenso[2] = unidades[parteInteira];
    }
    valorPorExtenso = string.Join(" ", extenso);
}

// Converta a parte decimal para sua forma por extenso
if (parteDecimal > 0)
{
    valorPorExtenso += " reais";
    if (parteDecimal >= 20)
    {
        valorPorExtenso += " e ";
        valorPorExtenso += dezenas[parteDecimal / 10];
        parteDecimal %= 10;
        if (parteDecimal > 0)
        {
            valorPorExtenso += " e ";
        }
    }
    if (parteDecimal > 0)
    {
        valorPorExtenso += unidades[parteDecimal];
    }
    valorPorExtenso += " centavos ";
}

Console.WriteLine(valorPorExtenso.ToUpper());