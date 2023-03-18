import { Component, OnInit } from '@angular/core';
import { LocalStorageService } from 'src/app/services/local-storage.service';

@Component({
  selector: 'app-main-page',
  templateUrl: './main-page.component.html',
  styleUrls: ['./main-page.component.scss']
})
export class MainComponent implements OnInit {
  welcomeMessage: string = "";

  constructor(
    private storageService: LocalStorageService,
  ) {}

  ngOnInit(): void {
    const login = this.storageService.getLogin();

    if (!login) {
      this.welcomeMessage = "It seems you are not registered yet. Anyway welcome, our service will come soon!";
    } else {
      this.welcomeMessage = `Welcome, ${login}, our service will be ready soon!`;
    }
  }
}
