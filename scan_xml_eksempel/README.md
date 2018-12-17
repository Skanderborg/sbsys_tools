# SKB_scan_sbsys_xml
I Skanderborg blev vi lidt udfordrede på at vi måtte skifte scannings software i skiftet til SBSYS. Vi løste problematikken ved at gå til et norsk firma og købte Pixedit, et billigt scannings program, der kan læse QR koder.

Selve fordelingen af det scannede post foregår gennem to Skanderborg udviklede apps. Med den ene kan vores postomdelere, fremsøge en medarbejder eller en afdelingspostkasse og printe en QR kode indeholdende dennes informationer. Pixedit står nu for scanningen og læsningen af QR koden, og til sidst har vi en service, som tager dokumenterne Pixedit leverer og laver navnene om til SBSYS-læsbar XML, som vi hælder i den store postfordelingsmappe på SBSYS service maskinen.

I dette projekt har vi stillet de centrale dele af vores interne fordelings app til rådighed. Det er den app, der danner XML til SBSYS og fordeler posten. Den app vi har opbygge til dannelse af QR-stregkoder bygger på et proprietary bibliotek til dannelse af QR koden, og er derfor ikke umiddelbart til deling, men konceptet er blot, at man danner et stregkode ark med en QR kode, der indeholder navnet på en SBSYS modtagerpostkasse.

I fremtiden er planen at det bliver SBSIP, der står for selve fordelingen.

UID BRUGER_.xml er XML eksempel på post sendt direkte til en bruger i SBSYS.

PID POSTKASSE_.xml er eksempel på post sendt direkte til en SBSYS postkasse.

Process:
![alt tag](https://raw.githubusercontent.com/SkanderborgKommune/SKB_scan_sbsys_xml/master/sbsysxmlbizagi.jpg)
