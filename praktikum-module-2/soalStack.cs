/*
 * Created by SharpDevelop.
 * User: acer
 * Date: 26/11/2023
 * Time: 21:46
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace praktikum_module_2
{
	/// <summary>
	/// Description of soalStack.
	/// </summary>
	public class SoalStack
	{
		// constructor
		public SoalStack() {
			while(true) {
				Console.WriteLine("Input:");
				String input = Console.ReadLine();
				Console.WriteLine("Output: ");
				Console.WriteLine(checkFormat(input));
				
				Console.Write("Ulangi lagi? (y/t) : ");
				string ulangLagi = Console.ReadLine();
				
				if (ulangLagi == "t") break;
				Console.Clear();
			}
		}
		
		
		/// <summary>
		/// Method untuk mengecek apakah dia kurung buka
		/// </summary>
		/// <param name="value">sebuah karakter</param>
		/// <returns>boolean</returns>
		public static bool isOpenPar(char value) {
			return value == '(' || value == '{' || value == '[' || value == '<';
		}
		
		/// <summary>
		/// Method untuk mengecek apakah dia kurung tutp
		/// </summary>
		/// <param name="value">Sebuah karakter</param>
		/// <returns>boolean</returns>
		public static bool isClosePar(char value) {
			return value == ')' || value == '}' || value == ']' || value == '>';
		}
		
		/// <summary>
		/// Method untuk mengecek format ekspreksi aritmatika
		/// </summary>
		/// <param name="value">input berisi sebuah ekspresi aritmatika</param>
		/// <returns>String baru</returns>
		public static String checkFormat(String value) {
			// Membuat stack yang akan diisi sebuah tanda kurung buka
			StackArr stack = new StackArr(value.Length);
			// membuat var error agar index dari value yang salah bisa diganti menjadi X
			int error = -1;
			
			//Melakukan looping sebanyak length dari value
			for (int i = 0; i < value.Length; i++) {
				
				// cek apakah di kurung buka
				if (isOpenPar(value[i])) {
					// jika iya kita push ke stack
					stack.Push(value[i].ToString());
					
					// cek jika dia bukan kurung buka, maka apakah dia
					// kurung tutup ?
				} else if (isClosePar(value[i])) {
					// Jika iya, cek lagi apakah stacknya kosong
					// atau apakah dia tidak match atau tidak berpasangan
					if (stack.IsEmpty() || !isMatched(char.Parse(stack.Pop()), value[i])) {
						// jika kondisi terpenuhi
						// maka initialize sebuah error terhadap index looping
						error = i;

						// kemudian kita keluarkan kurang buka dan break;
						stack.Pop();
						break;
					}
				}
				
				
			}
			
			// kita membuat char result untuk mengasign
			// sebuah index string menjadi x, di string tidak bisa
			// karena immutabole
			char[] result = value.ToCharArray();
			
			// cek jika errornya ada
			// maka lakukan assign dengan x
			if (error != -1) result[error] = 'X';
			
//			result[error + 1] = ' ';
			
			
			return handlePrintX(result);
		}
		
		/// <summary>
		/// Method untuk mengecek apakah beliau ini saling berpasangan atau tidak
		/// </summary>
		/// <param name="openPar">sebuah kurung buka</param>
		/// <param name="closePar">sebuah kurung tutup</param>
		/// <returns>sebuah boolean apakah dia pasangan atau tidak</returns>
		public static Boolean isMatched(char openPar, char closePar) {
			return (openPar == '(' && closePar == ')') ||
				(openPar == '{' && closePar == '}') ||
				(openPar == '[' && closePar == ']') ||
				(openPar == '<' && closePar == '>');
		}

		/// <summary>
		/// Method untuk menghandle print X, dimana suatu kondisi ketika ada value X maka value selanjutnya tidak akan diprint
		/// </summary>
		/// <param name="value">hasil dari assignment X</param>
		/// <returns>String baru</returns>
		public static String handlePrintX(char[] value) {
			// membuat variabel untuk return 
			String result = null;
			
			// mencari nilai X dengan looping for
			for (int i = 0; i < value.Length; i++) {
				// jika ada value X
				if (value[i] == 'X') {
					// Maka kita lakukan assignment kepada sebuah variabel result
					result += value[i];
					// lalu kita berhentikan sebuah looping dengan break;
					break;
				}
				// statement ini berfungsi untuk menghandle non X value
				result += value[i];
			}
			
			// Mengembalikan String baru
			return result;
		}
		
	}
}
