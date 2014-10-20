import java.util.ArrayList;
import java.util.Scanner;


public class _01_Problem1 {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		int n = input.nextInt();
		int[] nums = new int[n];
		for (int i = 0; i < n; i++) {
			nums[i] = input.nextInt();
		}
		if (n < 4) {
			System.out.println("No");
		} else {
			ArrayList<String> output = new ArrayList<>();
			for (int i = 0; i < nums.length; i++) {
				for (int j = 0; j < nums.length; j++) {
					for (int j2 = 0; j2 < nums.length; j2++) {
						for (int k = 0; k < nums.length; k++) {
							boolean check = nums[i] != nums[j] && nums[i] != nums[j2]
									&& nums[i] != nums[k] && nums[j] != nums[j2]
									&& nums[j] != nums[k] && nums[j2] != nums[k];
							if (check && (""+nums[i]+nums[j]).equals(""+nums[j2]+nums[k])) {
								output.add(nums[i]+"|"+nums[j]+"=="+nums[j2]+"|"+nums[k]);
							}
						}
					}
				}
			}
			if (output.isEmpty()) {
				System.out.println("No");
			}
			for (int i = 0; i < output.size(); i++) {
				System.out.println(output.get(i));
			}
		}

	}

}
