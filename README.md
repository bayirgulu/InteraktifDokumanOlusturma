# RaporlarmaService
Projede MS SQL Veri tabanı , Ön yüz için html js , arka plan işlemleri için c# .NET Fremwork Rest api kullanılmıştır.
boyutlarını bizim belirleybildiğimiz bir sayfanın içine html tooları ekleyerek taşıma bouyut büyütme ve özelliklerini değiştirebileceğimiz 
ve oluşturduğumuz yeni tasarımı database kaydedip istediğimiz zaman tekrardan çağırabileceğimiz bir proje.

Projeden Birkaç Görsel
![Özel![Raporlar](https://user-images.githubusercontent.com/63264874/218703150-4f50430e-16d6-4edd-8be7-4803c0860c9e.png)
likler](https://user-images.githubusercontent.com/63264874/218703131-1658b4bb-7aea-4d9c-9b8d-d93732594b26.png)
![SayfaOluşturma](https://user-images.githubusercontent.com/63264874/218703168-93d3e884-1fed-451a-adcb-c01002e304fc.png)



Projeyi Çalıştırmak için öncelikle DBScript textinin içindekileri sql managmenta yapıştırıp DB yi oluşturmalısınız.
DB yi yükledikten sonra RaporlamaService' nin içinde ValuesController ve DBbaglantiController daki SQL Connectionları kendinize göre değiştirmelisiniz.
benim makinamda servis https://localhost:44357 bu adresten çalışıyor sizde farklı bir porttan çalışabilir.
 Bu yüzden Create report (front end) klasöründeki index html dosyasından aratarak kendi port numaranızı değiştirebilirsiniz.
 ![host](https://user-images.githubusercontent.com/63264874/218701440-fe244e56-6d04-4816-9b65-a41074ceca5a.png)
