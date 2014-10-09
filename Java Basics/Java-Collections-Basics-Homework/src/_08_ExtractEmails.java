import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;


public class _08_ExtractEmails {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		String entry = input.nextLine();
		Pattern emailPattern = Pattern.compile("[\\w-+]+(?:\\.[\\w-+]+)*@(?:[\\w-]+\\.)+[a-zA-Z]{2,7}");
		Matcher matcher = emailPattern.matcher(entry);
		while (matcher.find()) {
			System.out.println(matcher.group());
		}
	}

}
