import java.util.ArrayList;
import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;


public class _01_Problem2 {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		String entryLine = input.nextLine();
		Pattern regex = Pattern.compile("[\\dJQKA]+");
		Matcher match = regex.matcher(entryLine);
		ArrayList<Integer> entry = new ArrayList<>();
		while (match.find()) {
			if (match.group().equals("J")) {
				entry.add(12);
			} else if (match.group().equals("Q")) {
				entry.add(13);
			} else if (match.group().equals("K")) {
				entry.add(14);
			} else if (match.group().equals("A")) {
				entry.add(15);
			} else {
				entry.add(Integer.parseInt(match.group()));
			}	
		}
		int sum = 0;
		for (int i = 0; i < entry.size(); i++) {
			int temp = 0;
			int equal = 1;
			for (int j = i+1; j < entry.size(); j++) {
				if (entry.get(i) == entry.get(j)) {
					equal++;
				} else {
					break;
				}
			}
			temp += equal * entry.get(i);
			if (equal != 1) {
				temp *= 2;
			}
			sum += temp;
			i += equal - 1;
		}
		System.out.println(sum);

	}

}
