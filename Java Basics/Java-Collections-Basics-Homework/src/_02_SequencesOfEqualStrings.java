import java.util.Scanner;
import java.util.Arrays;

public class _02_SequencesOfEqualStrings {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		String entryLine = input.nextLine();
		String[] entry = entryLine.split(" ");
		System.out.print(entry[0]);
		for (int i = 1; i < entry.length; i++) {
			if (entry[i].equals(entry[i - 1])) {
				System.out.print(" " + entry[i]);
			} else {
				System.out.println();
				System.out.print(entry[i]);
			}
		}
		
	}

}
