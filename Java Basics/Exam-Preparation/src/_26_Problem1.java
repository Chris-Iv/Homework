import java.util.Scanner;


public class _26_Problem1 {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		int hours = 0;
		int minutes = 0;
		while (true) {
			String entryLine = input.nextLine();
			if (entryLine.equals("End")) {
				break;
			}
			String[] entry = entryLine.split(":");
			hours += Integer.parseInt(entry[0]);
			minutes += Integer.parseInt(entry[1]);
		}
		hours += minutes / 60;
		minutes = minutes % 60;
		System.out.printf("%d:%02d", hours, minutes);
	}
}
