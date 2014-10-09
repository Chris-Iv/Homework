import java.util.Map;
import java.util.Scanner;
import java.util.TreeMap;


public class _11_MostFrequentWord {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		String entryLine = input.nextLine().toLowerCase();
		String[] entry = entryLine.split("([().,!?:;'\"-]|\\s)+");
		int counter = 0;
		Map<String, Integer> countWords = new TreeMap<>();
		for (String word : entry) {
			Integer count = countWords.get(word);
			if (count == null) {
				count = 0;
			}
			if (count + 1 > counter) {
				counter = count + 1;
			}
			countWords.put(word, count + 1);
		}
		for (Map.Entry<String, Integer> max : countWords.entrySet()) {
			if (max.getValue() == counter) {
				System.out.printf("%s -> %d times\n", max.getKey(), max.getValue());
			}
		}
	}

}
