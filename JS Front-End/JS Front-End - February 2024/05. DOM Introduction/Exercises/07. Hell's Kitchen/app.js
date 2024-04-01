function solve() {
	document.querySelector('#btnSend').addEventListener('click', onClick);

	function onClick() {
		let restaurantsInput = document.querySelector('#inputs textarea').value;
		restaurantsInput = JSON.parse(restaurantsInput);
		let restaurants = [];

		for (const restaurant of restaurantsInput) {
			let existingRestaurant = {};
			let isRestaurantAlreadyAdded = false;
			let totalSalary = 0;
			let bestSalary = 0;
			const [name, workers] = restaurant.split(' - ');
			let workersWithSalaries = [];

			if (restaurants.some(restaurant => restaurant.name === name)) {
				existingRestaurant = restaurants.find(restaurant => restaurant.name === name);
				totalSalary = existingRestaurant.totalSalary;
				bestSalary = existingRestaurant.bestSalary;
				workersWithSalaries = existingRestaurant.workersWithSalaries;
				isRestaurantAlreadyAdded = true;
			}

			for (const worker of workers.split(', ')) {
				let [workerName, salary] = worker.split(' ');
				salary = Number(salary);
				totalSalary += salary;

				if (salary > bestSalary) {
					bestSalary = salary;
				}

				const newWorker = {
					workerName,
					salary,
				};

				workersWithSalaries.push(newWorker);
			}

			if (!isRestaurantAlreadyAdded) {
				const newRestaurant = {
					name,
					bestSalary,
					totalSalary,
					workersWithSalaries,
				};

				restaurants.push(newRestaurant);
			} else {
				existingRestaurant.bestSalary = bestSalary;
				existingRestaurant.totalSalary = totalSalary;
			}
		}

		const bestRestaurant = selectAndEditTheBestRestaurantDetails(restaurants);

		printTheBestRestaurantDetails(bestRestaurant);
	}

	function selectAndEditTheBestRestaurantDetails(restaurants) {
		const bestRestaurant = restaurants
			.sort((a, b) => b.totalSalary / b.workersWithSalaries.length - a.totalSalary / a.workersWithSalaries.length)
			.shift();

		bestRestaurant.workersWithSalaries = bestRestaurant.workersWithSalaries.sort((a, b) => b.salary - a.salary);
		bestRestaurant.averageSalary = bestRestaurant.totalSalary / bestRestaurant.workersWithSalaries.length;

		return bestRestaurant;
	}

	function printTheBestRestaurantDetails(bestRestaurant) {
		const bestRestaurantOutputParagraph = document.querySelector('#bestRestaurant p');
		bestRestaurantOutputParagraph.textContent =
			`Name: ${bestRestaurant.name} Average Salary: ${bestRestaurant.averageSalary.toFixed(2)} Best Salary: ${bestRestaurant.workersWithSalaries[0].salary.toFixed(2)}`;

		const bestWorkersOutputParagraph = document.querySelector('#workers p');
		let workersOutput = '';

		for (const worker of bestRestaurant.workersWithSalaries) {
			workersOutput += `Name: ${worker.workerName} With Salary: ${worker.salary} `;
		}

		bestWorkersOutputParagraph.textContent = workersOutput.trim();
	}
}