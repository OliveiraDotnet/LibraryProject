using System.Text;
using System.Text.RegularExpressions;

namespace LibraryNet.Utils
{
    public readonly struct CpfCnpj
    {
        public string NumberId { get; }
        public ulong NumberCpfCnpj => ulong.TryParse(NumberId, out ulong valor) ? valor : 0;
        public string FormattedNumber => NumberId.Length > 11 ? NumberCpfCnpj.ToString(@"00\.000\.000\/0000\-00") : NumberCpfCnpj.ToString(@"000\.000\.000\-00");
        public bool IsValid { get; }
        public bool PhysicalPerson { get; }
        public bool LegalPerson { get; }
        public CpfCnpj(string cpfCnpj)
        {
            try
            {
                if (Regex.IsMatch(cpfCnpj, @"^(\d)\1*$"))
                {
                    IsValid = false;
                    NumberId = cpfCnpj.ToString();
                    PhysicalPerson = false;
                    LegalPerson = false;
                    return;
                }
            }
            catch (Exception)
            {
                IsValid = false;
                NumberId = cpfCnpj.ToString();
                PhysicalPerson = false;
                LegalPerson = false;
                return;
            }

            var sb = new StringBuilder();
            var numbers = new int[14];
            var pos = 0;
            var sum1 = 0;
            var sum2 = 0;
            var ninthDigit = 0;
            var tenthDigit = 0;
            foreach (var c in cpfCnpj.Where(char.IsDigit))
            {
                sb.Append(c);
                numbers[pos] = c - '0';

                sum1 += numbers[pos] * (10 - pos);
                sum2 += numbers[pos] * (11 - pos);
                switch (pos)
                {
                    case 8:
                        ninthDigit = sum1 * 10 % 11 % 10;
                        break;
                    case 9:
                        tenthDigit = sum2 * 10 % 11 % 10;
                        break;
                }
                pos++;
            }

            if (pos != 11 && pos != 14)
            {
                IsValid = false;
                NumberId = sb.ToString();
                PhysicalPerson = false;
                LegalPerson = false;
                return;
            }

            if (pos == 11)
            {
                NumberId = sb.ToString();
                PhysicalPerson = true;
                LegalPerson = false;
                IsValid = ninthDigit == numbers[9] && tenthDigit == numbers[10];
                return;
            }

            sum1 = sum2 = 0;
            pos = 6;
            for (int i = 13; i >= 1; i--)
            {
                sum2 += numbers[13 - i] * pos--;
                if (i == 13)
                    continue;
                pos++;
                sum1 += numbers[12 - i] * pos--;
                if (pos < 2)
                    pos = 9;
            }

            var digit13 = sum1 % 11 < 2 ? 0 : 11 - sum1 % 11;
            var digit14 = sum2 % 11 < 2 ? 0 : 11 - sum2 % 11;


            IsValid = digit13 == numbers[12] && digit14 == numbers[13];
            NumberId = sb.ToString();
            PhysicalPerson = false;
            LegalPerson = true;
        }
        private CpfCnpj(ulong numero) : this(numero.ToString(@"00000000000000"))
        {
        }

        public static implicit operator CpfCnpj(string valor)
        {
            return new CpfCnpj(valor);
        }
        public static implicit operator string(CpfCnpj cpfCnpj)
        {
            return cpfCnpj.NumberId;
        }
        public static implicit operator CpfCnpj(ulong valor)
        {
            return new CpfCnpj(valor);
        }
        public static implicit operator ulong(CpfCnpj cpfCnpj)
        {
            return cpfCnpj.NumberCpfCnpj;
        }
        public static bool operator ==(string valor, CpfCnpj cpfCnpj)
        {
            return valor == cpfCnpj.NumberId;
        }
        public static bool operator !=(string valor, CpfCnpj cpfCnpj)
        {
            return !(valor == cpfCnpj);
        }
        public bool Equals(CpfCnpj outro)
        {
            return NumberId == outro.NumberId;
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            return obj is CpfCnpj cpfCnpj && Equals(cpfCnpj);
        }
        public override int GetHashCode()
        {
            return NumberId != null ? NumberId.GetHashCode() : 0;
        }
    }
}