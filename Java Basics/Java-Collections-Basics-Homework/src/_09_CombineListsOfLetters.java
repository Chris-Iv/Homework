import java.util.ArrayList;
import java.util.Scanner;


public class _09_CombineListsOfLetters {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		ArrayList<Character> fstList = new ArrayList<Character>();
		ArrayList<Character> secList = new ArrayList<Character>();
		ArrayList<Character> combList = new ArrayList<Character>();
		for (char ch  : input.nextLine().toCharArray()) {
			fstList.add(ch);
		}
		for (char ch  : input.nextLine().toCharArray()) {
			secList.add(ch);
		}
		combList.addAll(fstList);
		for (int i = 0; i < secList.size(); i++) {
			if (fstList.contains(secList.get(i))) {
				continue;
			} else {
				combList.add(' ');
				combList.add(secList.get(i));
			}
		}
		for (int i = 0; i < combList.size(); i++) {
			System.out.print(combList.get(i));
		}
	}

}
