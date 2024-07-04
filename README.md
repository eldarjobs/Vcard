# VCard

Bu C# konsol proqramı RandomUser.me API-dən təsadüfi istifadəçi məlumatlarını əldə edir və bu məlumatları vCard (Virtual Əlaqə Faylı) formatına çevirir, sonra save edir.

## İstifadə Olunan API

Bu proqram RandomUser.me API-dən istifadə edir. API-dən məlumatları əldə etmək üçün HTTP sorğusu göndərir və gələn JSON məlumatlarını VCard sinfinə çevirir.

## VCard Sinfi

`VCard` sinfi aşağıdakı xüsusiyyətlərə malikdir:

- `Id`
- `Firstname`
- `Surname`
- `Email`
- `Phone`
- `Country`
- `City`

## İstifadə Qaydası

Tətbiq işə salındıqda istifadəçidən neçə vCard yaratmaq istədiyini soruşacaq. Yaradılan vCard-lar `.vcf` ,`.txt` uzantılı fayllar kimi "Vcard" qovluğunda saxlanılacaq.

## Əlavə Məlumat

Bu layihə C# dilində HTTP sorğuları, JSON məlumatların emalı, obyekt-yönümlü proqramlaşdırma və fayl əməliyyatları kimi mövzuları təcrübədən keçmək üçün hazırlanmışdır. Layihədə istifadə olunan API RandomUser.me tərəfindən təmin olunub.
