import { TestBed } from '@angular/core/testing';

import { AjouterNavbarPhotoService } from './ajouter-navbar-photo.service';

describe('AjouterNavbarPhotoService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: AjouterNavbarPhotoService = TestBed.get(AjouterNavbarPhotoService);
    expect(service).toBeTruthy();
  });
});
