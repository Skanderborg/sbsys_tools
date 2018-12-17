# SBSYS-Printer

Install rækkefølge:

novaPDF8PrinterDriver (til henholdsvis 32 eller 64 bit)

novaPDF8OEM (til henholdsvis 32 eller 64 bit)

SBSYSPrinterSkbApp (virker både på 32 og 64 bit - bliver automatisk placeret i C:\SBSys\SBSYSPrinterSkbApp\Database\ og kaldes herfra af sbsysprinteren)

OBS:

Kræver at SBSYS Dropfolderen er placeret på: C:\SBSys\DropFolder

Hvis dette ikke er tilfældet skal der bygges en ny installer, da NovaPDF desværre benytter en hardcodet sti.

(Kilde kode er også her på github, så i kan altid compile en ny version.)
