# 🐄 Farm Management

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
  - Ölüm nedenleri ayrı mesajlarla gösterilir  
- 📊 **DataGridView ve ListBox ile Anlık Takip**  
- 💾 **Veri Kaydı:** Oyundan çıkarken **farmData.txt** dosyasına otomatik kaydedilir, tekrar açınca devam edebilirsin

---

## 🖼️ Ekran Görüntüleri

Giriş Ekranı         |  Hayvan Yönetimi
------------------|------------------
<img width="665" height="532" alt="ff1" src="https://github.com/user-attachments/assets/40934d85-8b49-4c8a-8b4d-d12a8652d05e" />    |  <img width="1156" height="658" alt="ff3" src="https://github.com/user-attachments/assets/c3b46261-6842-4205-b8dd-b14482998d46" /> <img width="1145" height="665" alt="ff4" src="https://github.com/user-attachments/assets/dae7c7c5-d1b0-430d-b9aa-66e3756727b7" />

---

## 🚀 Nasıl Çalıştırılır?
Projeyi Klonla
- 1- git clone https://github.com/sefapasha/Farm_Management_Internship.git
- 2- Visual Studio ile aç
- 3- Farm_Management.UI projesini Startup Project yap
- 4- Run (F5) ile çalıştır

---

## 🗂️ Katmanlı Mimari
Farm_Management
- ├── EntityLayer      # Hayvan sınıfları (Cow, Sheep, Chicken)
- ├── Business         # AnimalManager (iş mantığı)
- ├── DataAccess       # farmData.txt ile veri kaydetme
- └── UI               # Windows Forms (oyunun arayüzü)

---
 
## 💾 Veri Kaydı
Çıkışta farmData.txt dosyasına şunlar kaydedilir:

Hayvan türü, yaşı, ürün sayısı, ömrü, fiyatı
Toplam bakiye
Uygulama açıldığında otomatik olarak yüklenir

## 🏆 Gelecek Planlar
🌐 API versiyonu (ASP.NET Core Web API)

📱 Mobil / Web arayüz

🎲 Rastgele olaylar: Market fiyat artışı, salgın hastalık vb.

👤 Geliştirici
Ahmet Sefa Ünal
