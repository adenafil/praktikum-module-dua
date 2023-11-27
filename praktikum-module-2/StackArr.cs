/*
 * Created by SharpDevelop.
 * User: acer
 * Date: 26/11/2023
 * Time: 21:44
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace praktikum_module_2
{
	/// <summary>
	/// Description of Class1.
	/// </summary>
	public class StackArr

	{

		public int Top;

		public String[] ArrayData;

		public int MaxSize;
		
		public StackArr(int maxSize) {
			this.MaxSize = maxSize;

			// create array instance berdasarkan maksimal size

			this.ArrayData = new String[maxSize];

			

			// inisialisasi Top dengan nilai -1 (stack kosong)

			this.Top = -1;
		}

			

		

		/// <summary>

		/// Fungsi untuk menambahkan data ke dalam stack

		/// </summary>

		/// <param name="data">Data yang akan ditambahkan</param>

		public void Push(String data)

		{

			// cek apakah top merupakan indeks tertinggi dari array

			if(this.Top == this.MaxSize-1) {

				// jika ya, maka tampilkan pesan bahwa stack penuh

				Console.WriteLine("Stack sudah penuh!");

			}

			else {

				// jika tidak, maka increment indeks top

				this.Top++;

				// lalu masukkan data ke array pada indeks top

				ArrayData[this.Top] = data;

			}

		}

		

		/// <summary>

		/// Fungsi untuk melihat data paling atas dari stack

		/// </summary>

		/// <returns>Mengembalikan data teratas atau -1 jika stack kosong</returns>

		public String Peek()

		{

			// cek apakah stack kosong

			if(this.Top == -1) {

				Console.WriteLine("Stack masih kosong!");

				return null;

			}			

			else {

				// jika tidak kosong, tampilkan data pada indeks Top

				return this.ArrayData[this.Top];

			}				

		}

		

		/// <summary>

		/// Fungsi untuk mengeluarkan data teratas dari stack

		/// </summary>

		/// <returns>Mengembalikan data teratas atau -1 jika stack kosong</returns>

		public String Pop()

		{

			// cek apakah stack kosong

			if(this.Top == -1) {

				Console.WriteLine("Stack masih kosong!");

				return null;

			}			

			else {

				// jika tidak kosong, simpan data pada indeks Top

				String popped = this.ArrayData[this.Top];

				// decrement index Top

				this.Top--;

				return popped;

			}						

		}

		

		public bool IsEmpty() 

		{

			return this.Top == -1;

		}

	}
}
