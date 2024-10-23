using System;

public enum NICType
{
    Ethernet,
    TokenRing
}

public class NIC
{
    private static NIC instance = null;

    public string Manufacture { get; private set; }
    public string MACAddress { get; private set; }
    public NICType Type { get; private set; }

    private NIC(string manufacture, string macAddress, NICType type)
    {
        Manufacture = manufacture;
        MACAddress = macAddress;
        Type = type;
    }

    public static NIC GetInstance(string manufacture, string macAddress, NICType type)
    {
        if (instance == null)
        {
            instance = new NIC(manufacture, macAddress, type);
        }
        return instance;
    }

    public override string ToString()
    {
        return $"NIC Info: \nManufacture: {Manufacture}\nMAC Address: {MACAddress}\nType: {Type}";
    }
}

public class Program
{
    public static void Main()
    {
        NIC nic = NIC.GetInstance("Intel", "00-14-22-01-23-45", NICType.Ethernet);

        Console.WriteLine(nic.ToString());

        NIC anotherNic = NIC.GetInstance("AnotherManufacturer", "00-14-22-67-89-AB", NICType.TokenRing);

        Console.WriteLine(anotherNic.ToString());
    }
}
