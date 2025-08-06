# 🐄 Barn Case Management

Windows Forms tabanlı bir **Hayvan Çiftliği Simülasyonu**.  
Oyunda inek, koyun ve tavuk alabilir, ürünlerini toplayıp satabilir ve çiftliğinizi büyütebilirsiniz.  
Hayvanlar zamanla yaşlanır, ürün üretir ve ömürleri dolunca ölür.

---

## ✨ Özellikler

- 🐓 **Hayvan Yönetimi:** İnek, Koyun ve Tavuk ekleme/satma  
- ⏳ **Yaşam Döngüsü:** Hayvanlar yaşlanır, üretir ve ömrü dolunca ölür  
- 🥚 **Ürün Üretimi:** Her hayvan belli aralıklarla ürün üretir  
- 💰 **Ekonomi:** Ürünleri satıp para kazan, yeni hayvanlar al  
- ⚡ **Gerçekçilik:**  
  - Hayvanlar şansa bağlı erken ölebilir (hastalık vb.)  
  - Ölüm nedenleri ayrı mesajlarla belirtilir  
- 📊 **DataGridView ve ListBox ile Anlık Takip**  
- 💾 **Veri Kaydı:** Oyundan çıkarken **farmData.txt** dosyasına otomatik kaydedilir, tekrar açınca devam edebilirsin

---

## 🖼️ Ekran Görüntüleri

Ana Ekran         |  Hayvan Yönetimi
------------------|------------------
[Buraya Resim]    |  [Buraya Resim]
🚀 Nasıl Çalıştırılır?
Projeyi Klonla
1- git clone https://github.com/KULLANICI_ADI/BarnCaseManagement.git
2- Visual Studio ile aç
3- Barn_Case_Deneme.UI projesini Startup Project yap
4- Run (F5) ile çalıştır

 🗂️ Katmanlı Mimari
Barn_Case_Deneme
 ├── EntityLayer      # Hayvan sınıfları (Cow, Sheep, Chicken)
 ├── Business         # AnimalManager (iş mantığı)
 ├── DataAccess       # farmData.txt ile veri kaydetme
 └── UI               # Windows Forms (oyunun arayüzü)
 
💾 Veri Kaydı
Çıkışta farmData.txt dosyasına şunlar kaydedilir:

Hayvan türü, yaşı, ürün sayısı, ömrü, fiyatı
Toplam bakiye
Uygulama açıldığında otomatik olarak yüklenir

🏆 Gelecek Planlar
🌐 API versiyonu (ASP.NET Core Web API)

📱 Mobil / Web arayüz

🎲 Rastgele olaylar: Market fiyat artışı, salgın hastalık vb.

👤 Geliştirici
Ahmet Sefa Ünal
