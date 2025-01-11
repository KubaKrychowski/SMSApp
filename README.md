# System Zarządzania Studentami (SMS)
## Przegląd
System Zarządzania Studentami to prosta aplikacja crossplatformowa oparta na frameworku .NET MAUI pozwalająca na zarządzanie listą uczniów.



## Funkcje
### Dodawanie, Usuwanie, Aktualizowanie i Wyświetlanie Danych Studentów: System umożliwia wykonanie podstawowych operacji CRUD.

### Obliczanie Średniej Oceny: System oblicza i wyświetla średnią ocen wszystkich studentów zapisanych w bazie danych.

### Łączność z Bazą Danych w pamięci aplikacji: SQLite jest używane do przechowywania danych studentów.

### Walidacja Danych: System zapewnia, że dane wprowadzone przez użytkownika są poprawne (np. wiek musi być liczbą dodatnią, a ocena musi mieścić się w zakresie od 0,0 do 100,0).

## Instrukcje instalacji
Należy zainstalować Visual Studio obsługujące .NET 8 oraz zainstalować do niego bibliotekę do obsługi aplikacji MAUI.
Plik bazy danych jest tworzony w pamięci urządzenia a tabele generują się automatycznie.

## Kompilacja i Uruchomienie Aplikacji:

Aby uruchomić aplikację należy użyć dedykowanego kompilatora oraz emulatora aplikacji windows pod nazwą *"Windows Machine"*. Aplikacja nie została przetestowana na urządzeniu Android/IOS.

### Interfejs StudentManager: 
Definiuje operacje na danych studentów, takie jak dodawanie, usuwanie, aktualizowanie, wyświetlanie wszystkich studentów i obliczanie średniej ocen.

### Klasa StudentManagerImpl: 
Implementuje interfejs StudentManager i zawiera metody do interakcji z bazą danych (SQLite).

### Obsługa Wyjątków
Aplikacja posiada obsługę wyjątków poprzez wyświetlenie komunikatu błędu. Metody operujące na bazie danych są otoczone blokiem try catch. Głównym założeniem było dodanie global exception handlera natomiast platforma do dziś dzień, nie wspiera w pełni tego rozwiązania przez co dochodzi do sytuacji przerwania głównego wątku pomimo obsługi błędu.
