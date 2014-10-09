import java.util.Scanner;


public class _04_LongestIncreasingSequence {

	public static void main(String[] args) {
		Scanner in = new Scanner(System.in);
		String input = in.nextLine();
		String[] entry = input.split(" ");
		int firstNumber = Integer.valueOf(entry[0]);
		int counter = 1;
		int sequenceCounter = 1;
		int position = 0;
		System.out.print(firstNumber);
		for (int i = 1; i < entry.length; i++) {
			int secondNumber = Integer.valueOf(entry[i]);
			if (secondNumber > firstNumber) {
				System.out.print(" " + secondNumber);
				counter++;
			} else {
				System.out.println();
				System.out.print(secondNumber);
				counter = 1;
			}
			if (counter > sequenceCounter) {
				sequenceCounter = counter;
				position = i;
			}
			firstNumber = secondNumber;
		}
		System.out.println();
		System.out.print("Longest: ");
		for (int i = 0; i < counter - 1; i++) {
			String longestSequence = entry[position - counter + 1 + i];
			System.out.print(longestSequence + " ");
		}
		System.out.println(entry[position]);
	}

}
