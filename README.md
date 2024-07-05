# VCard

Bu C# konsol proqramı RandomUser.me API-dən təsadüfi istifadəçi məlumatlarını əldə edir və bu məlumatları vCard (Virtual Əlaqə Faylı) formatına çevirir, sonra save edir.
Həmçinin olaraq bu konsol proqramı vasitəsi ilə həmçinin ayrı ölkə mənsublarına məxsus datalarıda çəkmək üçün istifadə etmek olur(Məsələn sizə Turkiye regionundan melumatlar lazımdırsa seçim edib melumatlari elde ede bilirsiniz)

## VCard Sinfi

`VCard` sinfi aşağıdakı xüsusiyyətlərə malikdir:

- `Id`
- `Firstname`
- `Surname`
- `Email`
- `Phone`
- `Country`
- `City`
- 
## İstifadə Olunan API

Bu proqram RandomUser.me api-dən istifadə edir. API-dən məlumatları əldə etmək üçün HTTP sorğusu göndərir və gələn JSON məlumatlarını VCard sinfinə çevirir.

  

