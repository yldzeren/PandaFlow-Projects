import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AnimalService {
  private apiUrl = 'http://localhost:5295/api/animals/';

  constructor(private http: HttpClient) {}

  getAnimals(): Observable<any[]> {
    return this.http.get<any[]>(this.apiUrl);
  }

  addAnimal(animal: any): Observable<any> {
    return this.http.post<any>(this.apiUrl, animal);
  }

  removeAnimal(animal: any): Observable<any> {
    return this.http.delete<any>(`${this.apiUrl}/${animal.id}`);
  }
}
