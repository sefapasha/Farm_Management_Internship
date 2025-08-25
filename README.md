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
  <img width="665" height="533" alt="ff1" src="https://github.com/user-attachments/assets/75100b25-568f-4cc9-953d-acf674550bcc" /> | <img width="1157" height="665" alt="ff2" src="https://github.com/user-attachments/assets/7da6000c-2823-41d6-821e-169d044ea526" /> <img width="1157" height="668" alt="ff3" src="https://github.com/user-attachments/assets/12519d67-75f5-4010-83e0-cb1d7f4853cf" />


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
