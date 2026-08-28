using System;

public class TrainController
{
    // ==============================
    // ZÁKLADNÍ PARAMETRY SOUPRAVY
    // ==============================

    public double Rychlost { get; private set; }
    public double MaximalniRychlost { get; } = 80.0;

    public double Zrychleni { get; } = 1.2;
    public double Brzdeni { get; } = 2.5;

    // ==============================
    // STAV SOUPRAVY
    // ==============================

    public bool DvereOtevrene { get; private set; }
    public bool SvetlaZapnuta { get; private set; } = true;
    public bool NouzovaBrzda { get; private set; }

    public bool JePripravenaKJizde
    {
        get
        {
            return !DvereOtevrene && !NouzovaBrzda;
        }
    }

    // ==============================
    // OVLÁDÁNÍ
    // ==============================

    public void Zrychlit()
    {
        if (!JePripravenaKJizde)
            return;

        Rychlost += Zrychleni;

        if (Rychlost > MaximalniRychlost)
            Rychlost = MaximalniRychlost;
    }

    public void Brzdit()
    {
        Rychlost -= Brzdeni;

        if (Rychlost < 0)
            Rychlost = 0;
    }

    public void NouzoveBrzdeni()
    {
        NouzovaBrzda = true;
        Rychlost = 0;
    }

    public void ZrusitNouzovouBrzdu()
    {
        NouzovaBrzda = false;
    }

    // ==============================
    // DVEŘE
    // ==============================

    public void OtevritDvere()
    {
        if (Rychlost > 0)
            return;

        DvereOtevrene = true;
    }

    public void ZavritDvere()
    {
        DvereOtevrene = false;
    }

    public void PrepnoutDvere()
    {
        if (DvereOtevrene)
            ZavritDvere();
        else
            OtevritDvere();
    }

    // ==============================
    // SVĚTLA
    // ==============================

    public void PrepnoutSvetla()
    {
        SvetlaZapnuta = !SvetlaZapnuta;
    }

    // ==============================
    // KLAKSON
    // ==============================

    public void Klakson()
    {
        Console.WriteLine("HOUKÁNÍ!");
    }

    // ==============================
    // INFORMACE O SOUPRAVĚ
    // ==============================

    public void ZobrazitStav()
    {
        Console.WriteLine("--------------------------------");
        Console.WriteLine("STAV SOUPRAVY");
        Console.WriteLine("--------------------------------");

        Console.WriteLine(
            $"Rychlost: {Rychlost:0.0} km/h"
        );

        Console.WriteLine(
            $"Dveře: {(DvereOtevrene ? "Otevřené" : "Zavřené")}"
        );

        Console.WriteLine(
            $"Světla: {(SvetlaZapnuta ? "Zapnutá" : "Vypnutá")}"
        );

        Console.WriteLine(
            $"Nouzová brzda: {(NouzovaBrzda ? "AKTIVNÍ" : "Vypnutá")}"
        );

        Console.WriteLine("--------------------------------");
    }
}
