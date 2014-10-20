import java.util.HashSet;
import java.util.Scanner;


public class _22_Problem1 {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		String entryLine = input.nextLine();
		String[] entry = entryLine.split("[^a-zA-Z]+");
		HashSet<String> output = new HashSet<>();
		
		for (int i = 0; i < entry.length; i++) {
			String firstWord = entry[i];
			for (int j = 0; j < entry.length; j++) {
				String secondWord = entry[j];
				for (int k = 0; k < entry.length; k++) {
					String thirdWord = entry[k];
					if (firstWord != secondWord) {
						boolean check = (firstWord + secondWord).equals(thirdWord);
						if (check) {
							output.add(firstWord + "|" + secondWord + "=" + thirdWord);
						}
					}
				}
			}
		}
		
		if (output.isEmpty()) {
			System.out.println("No");
		} else {
			for (String words : output) {
				System.out.println(words);
			}
		}
	}

}
