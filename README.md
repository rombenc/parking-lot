# Parking Lot System

Parking Lot System adalah aplikasi console sederhana untuk mengelola tempat parkir. Aplikasi ini memungkinkan Anda untuk membuat tempat parkir, memarkir kendaraan, dan mengambil laporan status parkir.

## Fitur

- Buat tempat parkir
- Parkir kendaraan
- Keluar kendaraan
- Lihat status tempat parkir
- Hitung jumlah kendaraan berdasarkan jenis
- Dapatkan nomor registrasi kendaraan berdasarkan jenis pelat (ganjil/genap)
- Dapatkan nomor registrasi kendaraan berdasarkan warna
- Dapatkan nomor slot berdasarkan warna kendaraan
- Dapatkan nomor slot berdasarkan nomor registrasi kendaraan

## Cara Penggunaan

### Perintah Tersedia

- `create_parking_lot <jumlah_slot>`: Membuat tempat parkir dengan jumlah slot yang ditentukan.
- `park <nomor_registrasi> <warna_kendaraan> <jenis_kendaraan>`: Parkir kendaraan dengan nomor registrasi, warna, dan jenis tertentu.
- `leave <nomor_slot>`: Mengeluarkan kendaraan dari slot yang ditentukan.
- `status`: Menampilkan status tempat parkir saat ini.
- `type_of_vehicles <jenis_kendaraan>`: Menampilkan jumlah kendaraan berdasarkan jenis.
- `registration_numbers_for_vehicles_with_odd_plate`: Menampilkan nomor registrasi kendaraan dengan pelat ganjil.
- `registration_numbers_for_vehicles_with_even_plate`: Menampilkan nomor registrasi kendaraan dengan pelat genap.
- `registration_numbers_for_vehicles_with_colour <warna>`: Menampilkan nomor registrasi kendaraan berdasarkan warna.
- `slot_numbers_for_vehicles_with_colour <warna>`: Menampilkan nomor slot kendaraan berdasarkan warna.
- `slot_number_for_registration_number <nomor_registrasi>`: Menampilkan nomor slot berdasarkan nomor registrasi kendaraan.
- `exit`: Keluar dari aplikasi.

### Contoh Penggunaan

1. **Buat tempat parkir**:
   ```bash
   create_parking_lot 6
