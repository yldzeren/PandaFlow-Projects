import { Component, OnInit } from '@angular/core';
import { AnimalService } from './services/animal.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  animals: any[] = [];
  newAnimalName: string = '';

  constructor(private animalService: AnimalService) {}

  ngOnInit() {
    debugger;
    this.getAnimals();
  }

  getAnimals() {
    this.animalService.getAnimals().subscribe((animals: any[]) => {
      this.animals = animals;
    });
  }

  addAnimal() {
    if (this.newAnimalName.trim() !== '') {
      this.animalService.addAnimal({ name: this.newAnimalName }).subscribe(() => {
        this.getAnimals();
        this.newAnimalName = '';
      });
    }
  }

  removeAnimal(animal: any) {
    this.animalService.removeAnimal(animal).subscribe(() => {
      this.getAnimals();
    });
  }
}
