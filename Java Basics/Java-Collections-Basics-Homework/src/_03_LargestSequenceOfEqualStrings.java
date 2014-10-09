import java.util.Scanner;


public class _03_LargestSequenceOfEqualStrings {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		String entryLine = input.nextLine();
		String[] entry = entryLine.split(" ");
		int secondCounter = 1;
		int counter = 1;
		int position = 0;
		for (int i = 1; i < entry.length; i++) {
			if (entry[i].equals(entry[i - 1])) {
				counter++;
			} else {
				counter = 1;
			}
			if (counter > secondCounter) {
				secondCounter = counter;
				position = i;
			}
		}
		for (int i = 0; i < secondCounter - 1; i++) {
			System.out.print(entry[position] + " ");
		}System.out.println(entry[position]);
	}

}
