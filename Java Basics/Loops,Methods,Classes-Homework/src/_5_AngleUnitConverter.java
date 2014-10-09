import java.util.Scanner;


public class _5_AngleUnitConverter {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		int n = input.nextInt();
		String radToDeg = "rad";
		String degToRad = "deg";
		double rad = 0;
		double deg = 0;
		for (int i = 0; i < n; i++) {
			double entry = input.nextDouble();
			String conversionType = input.next();
			if (conversionType.equals(radToDeg)) {
				rad = entry;
				deg = radToDegConv(rad);
				System.out.println(deg + " " + "deg");
			} else if (conversionType.equals(degToRad)) {
				deg = entry;
				rad = degToRadConv(deg);
				System.out.println(rad + " " + "rad");
			}
		}
	}
	public static double radToDegConv(double rad) {
		double deg = rad * 180 / Math.PI;
		return deg;
	}
	public static double degToRadConv(double deg) {
		double rad = deg * Math.PI / 180;
		return rad;
	}

}
