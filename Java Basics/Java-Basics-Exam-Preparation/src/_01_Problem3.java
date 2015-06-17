import java.math.BigDecimal;
import java.util.ArrayList;
import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;


public class _01_Problem3 {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		String entryLine = input.nextLine();
		ArrayList<String> numbers = new ArrayList<>();
		ArrayList<String> operators = new ArrayList<>();
		Pattern numsRegex = Pattern.compile("[\\d\\.]+");
		Matcher matchNums = numsRegex.matcher(entryLine);
		Pattern operatorsRegex = Pattern.compile("[+-]+");
		Matcher matchOperators = operatorsRegex.matcher(entryLine);
		while (matchNums.find()) {
			numbers.add(matchNums.group());	
		}
		while (matchOperators.find()) {
			operators.add(matchOperators.group());
		}
		BigDecimal result = new BigDecimal(numbers.get(0));
		for (int i = 0; i < operators.size(); i++) {
			if (operators.get(i).equals("+")) {
				result = result.add(new BigDecimal(numbers.get(i+1)));
			} else {
				result = result.subtract(new BigDecimal(numbers.get(i+1)));
			}
		}
		System.out.println(result);

	}

}
