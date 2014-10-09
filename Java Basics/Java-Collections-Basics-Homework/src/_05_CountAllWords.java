import java.util.Scanner;


public class _05_CountAllWords {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		String entryLine = input.nextLine();
		String[] entry = entryLine.split("\\W+");
		System.out.println(entry.length);
	}

}
