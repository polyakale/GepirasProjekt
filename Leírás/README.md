# Gépírás
A program célja, hogy elemzést végezzen a gépírás mintákról. A program a `szoveg.txt` és a `fingerOrder.csv` fájlokat olvassa be, majd statisztikai elemzést végez az ujjak terheléséről, és létrehoz egy `karakteradatgyujtes.txt` fájlt, amely tartalmazza, hogy melyik karaktert melyik ujj hányszor nyomta le.
## Működés
1. Megállapítjuk hogy a `szoveg.txt` létezik-e.

![](ifExistTextFileCode.png)

2. Itt a statisztikai elmezést végezük el.

![](StatisztikaKíszámolásaCode.png)

És a console-on jól áttekinthető formában megjeleníti az ujjak százalékos és számszerű terhelését.

![](TáblázatosanKiírjaÉsSzázalékbanIsMegedjaAzUjjakTerhelését.png)
<center>||
<center>\/</center>

![](ConsoleLíirás.png)
![](KözépreZár.png)
Az adatok középrezárása.

</center>

3. Elkészítjük a `karakteradatgyujtes.txt` fájlt.

![](FileKreálás.png)

