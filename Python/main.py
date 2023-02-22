# Listas de palavras para números de 0 a 999
unidades = ["zero", "um", "dois", "três", "quatro", "cinco", "seis", "sete", "oito", "nove"]
dezenas = ["", "", "vinte", "trinta", "quarenta", "cinquenta", "sessenta", "setenta", "oitenta", "noventa"]
centenas = ["", "cem", "duzentos", "trezentos", "quatrocentos", "quinhentos", "seiscentos", "setecentos", "oitocentos", "novecentos"]

# Receber valor como entrada do usuário
valor = input("Digite um valor: ")
valor = float(valor.replace(",", "."))

# Separe o valor em parte inteira e decimal
parte_inteira = int(valor)
parte_decimal_string = "{:.0f}".format((valor - parte_inteira) * 100)

parte_decimal = int(parte_decimal_string)

# Converta a parte inteira para sua forma por extenso
if parte_inteira == 0:
    valor_extenso = "zero"
else:
    extenso = []
    if parte_inteira >= 100:
        extenso.append(centenas[parte_inteira // 100])
        parte_inteira %= 100
        if parte_inteira == 0 and parte_decimal == 0:
            extenso.append("de")
    if parte_inteira >= 20:
        extenso.append(dezenas[parte_inteira // 10])
        parte_inteira %= 10
    if parte_inteira > 0 or len(extenso) == 0:
        extenso.append(unidades[parte_inteira])
    valor_extenso = " e ".join(extenso)

# Converta a parte decimal para sua forma por extenso
if parte_decimal > 0:
    extenso_decimal = " reais "
    if parte_decimal >= 20:
        extenso_decimal += "e "
        extenso_decimal += dezenas[parte_decimal // 10]
        valor_extenso += extenso_decimal
        parte_decimal %= 10
        if parte_decimal > 0:
            valor_extenso += " e "
        if parte_decimal > 0:
            valor_extenso += unidades[parte_decimal]
    valor_extenso += " centavos"
print(valor_extenso.upper())