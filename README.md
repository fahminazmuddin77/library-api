# Library API

## Video Presentasi

Link: https://youtu.be/oTo7qOJikiA


## Deskripsi Project

Project ini merupakan REST API untuk mengelola data buku pada sistem perpustakaan. API ini mendukung operasi CRUD (Create, Read, Update, Delete) dan menggunakan relasi antar tabel dalam database PostgreSQL.



## Domain

Domain yang dipilih adalah sistem perpustakaan (Library System) yang terdiri dari data buku, kategori, dan user.



## Teknologi yang Digunakan

* Bahasa: C#
* Framework: ASP.NET Core Web API
* Database: PostgreSQL
* Library: Dapper



## Cara Menjalankan Project

### 1. Clone Repository


git clone https://github.com/fahminazmuddin77/library-api.git


### 2. Import Database

* Buka pgAdmin
* Buat database baru dengan nama: library_api
* Jalankan file database.sql

### 3. Konfigurasi Database

Buka file appsettings.json, lalu ubah connection string:


"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Port=5432;Database=library_api;Username=postgres;Password=YOUR_PASSWORD"
}


### 4. Jalankan Project

* Buka project di Visual Studio 2022
* Tekan F5 atau klik Run

### 5. Akses API (Swagger)

(https://localhost:7000/swagger/index.html)


## Daftar Endpoint API

| Method | URL             | Keterangan                           |
| ------ | --------------- | ------------------------------------ |
| GET    | /api/books      | Mengambil semua data buku            |
| GET    | /api/books/{id} | Mengambil detail buku berdasarkan ID |
| POST   | /api/books      | Menambahkan data buku                |
| PUT    | /api/books/{id} | Mengupdate data buku                 |
| DELETE | /api/books/{id} | Menghapus data buku                  |



## Import Database

Gunakan file database.sql untuk membuat tabel dan mengisi sample data.



## Keamanan

Semua query menggunakan parameterized query (Dapper) untuk mencegah SQL Injection.



## Author

Nama: Mohammad Fahmi Nazmuddin
NIM: (242410102011)
