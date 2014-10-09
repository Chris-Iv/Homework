import java.util.Date;
import java.util.Scanner;
import java.text.SimpleDateFormat;
import java.text.ParseException;

public class _7_DaysBetweenTwoDates {

	public static void main(String[] args) throws ParseException {
		Scanner input = new Scanner(System.in);
		String firstDate = input.next();
		String secondDate = input.next();
		SimpleDateFormat simpleDateFormat = new SimpleDateFormat("dd-MM-yyyy");
		Date date1 = simpleDateFormat.parse(firstDate);
		Date date2 = simpleDateFormat.parse(secondDate);
		System.out.println((int)days(date1, date2));
	}
	public static double days(Date d1, Date d2) {
		long diff = 0;
		diff = d2.getTime() - d1.getTime();
		return ((double) diff) / (86400 * 1000);
	}
}
