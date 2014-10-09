import java.util.Scanner;
import java.util.Set;
import java.util.TreeSet;


public class _10_ExtractAllUniqueWords {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		String entryLine = input.nextLine().toLowerCase();
		String[] entry = entryLine.split("\\W");
		Set<String> text = new TreeSet<>();
		for (String word : entry) {
			text.add(word);
		}
		for (String word : text) {
			System.out.print(word + " ");
		}
	}

}
